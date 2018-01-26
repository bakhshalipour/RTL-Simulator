using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Data;
using Microsoft.CSharp;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace RTLClass
{
    class RTL
    {
        public List<string> regNames { get; set; }
        public List<string> regVals { get; set; }
        public List<string> code { get; set; }
        public int regCount;
        public List<string> normalizedCondiotions;
        public List<string> normalizedRTs;
        public List<string> normalizedLHS;
        public List<string> normalizedRHS;
        public List<int> indexOfNormalizedLHS;
        public bool simulationEnd;

        //CodeDom Variables
        ArrayList _mathMembers;
        Hashtable _mathMembersMap;
        StringBuilder _source;

        string compileMessage;
        string compileResult;


        //Constructor
        public RTL(List<string> regNames, List<string> regVals, List<string> code)
        {
            this.regNames = regNames;
            this.regVals = regVals;
            this.code = code;
            normalizedCondiotions = new List<string>();
            normalizedRTs = new List<string>();
            normalizedLHS = new List<string>();
            normalizedRHS = new List<string>();
            indexOfNormalizedLHS = new List<int>();
            simulationEnd = false;

            _mathMembers = new ArrayList();
            _mathMembersMap = new Hashtable();
            _source = new StringBuilder();
            compileMessage = null;
            compileResult = null;

            GetMathMemberNames();
            InitializeMyComponents();
        }

        public void InitializeMyComponents()
        {
            regCount = regNames.Count;

            for (int i = 0; i < code.Count; i++)
            {
                string RTLine = code[i];
                string[] conditionPlusRT = RTLine.Split(':');
                string lineCondition = conditionPlusRT[0];
                string lineRT = conditionPlusRT[1];
                string[] tempRTs = lineRT.Split(',');
                foreach (var rt in tempRTs)
                {
                    normalizedCondiotions.Add(lineCondition);
                    normalizedRTs.Add(rt);
                }
            }

            foreach (var c in normalizedRTs)
            {
                int index = c.IndexOf('<');
                int cSize = c.Length;
                string t1 = c.Substring(0, index);
                string t2 = c.Substring(index + 2);
                normalizedLHS.Add(t1);
                normalizedRHS.Add(t2);
            }

            for (int i = 0; i < normalizedLHS.Count; i++)
            {
                indexOfNormalizedLHS.Add(regNames.IndexOf(normalizedLHS[i]));
            }
        }

        public void ExecuteOneClock()
        {
            List<bool> truenessOfCondiotions = new List<bool>();
            List<string> valueOfRHS = new List<string>();
            List<string> tempConditions = new List<string>(normalizedCondiotions);
            List<string> tempRHS = new List<string>(normalizedRHS);

            for (int i = 0; i < tempConditions.Count; i++)
            {
                for (int j = 0; j < regNames.Count; j++)
                    tempConditions[i] = tempConditions[i].Replace(regNames[j], regVals[j]);
            }

            for (int i = 0; i < tempRHS.Count; i++)
                for (int j = 0; j < regNames.Count; j++)
                    tempRHS[i] = tempRHS[i].Replace(regNames[j], regVals[j]);

            simulationEnd = true;

            for (int i = 0; i < tempConditions.Count; i++)
            {
                tempConditions[i] = tempConditions[i].Replace("True", "true").Replace("False", "false");
                evaluateUsingCompiler(tempConditions[i]);

                if (compileResult != "False" && compileResult != "0")
                {
                    simulationEnd = false;
                    truenessOfCondiotions.Add(true);
                }
                else
                    truenessOfCondiotions.Add(false);
            }

            for (int i = 0; i < tempRHS.Count; i++)
            {
                evaluateUsingCompiler(tempRHS[i]);
                valueOfRHS.Add(compileResult);
            }

            for (int i = 0; i < truenessOfCondiotions.Count; i++)
            {
                if (truenessOfCondiotions[i])
                    regVals[indexOfNormalizedLHS[i]] = valueOfRHS[i];
            }

        }

        public void evaluateUsingCompiler(string inputString)
        {
            compileMessage = null;
            compileResult = null;
            string expression = RefineEvaluationString(inputString);
            BuildClass(expression);
            CompilerResults results = CompileAssembly();
            compileMessage += Environment.NewLine + _source.ToString();

            if (results != null && results.CompiledAssembly != null)
            {
                // run the evaluation function
                RunCode(results);
            }

            else
            {
            }
        }

        void GetMathMemberNames()
        {
            // get a reflected assembly of the System assembly
            Assembly systemAssembly = Assembly.GetAssembly(typeof(System.Math));
            try
            {
                //cant call the entry method if the assembly is null
                if (systemAssembly != null)
                {
                    //Use reflection to get a reference to the Math class

                    Module[] modules = systemAssembly.GetModules(false);
                    Type[] types = modules[0].GetTypes();

                    //loop through each class that was defined and look for the first occurrance of the Math class
                    foreach (Type type in types)
                    {
                        if (type.Name == "Math")
                        {
                            // get all of the members of the math class and map them to the same member
                            // name in uppercase
                            MemberInfo[] mis = type.GetMembers();
                            foreach (MemberInfo mi in mis)
                            {
                                _mathMembers.Add(mi.Name);
                                _mathMembersMap[mi.Name.ToUpper()] = mi.Name;
                            }
                        }
                        //if the entry point method does return in Int32, then capture it and return it
                    }


                    //if it got here, then there was no entry point method defined.  Tell user about it
                }
            }
            catch (Exception ex)
            {
                compileMessage = "Error:  An exception occurred while executing the script";
            }
        }

        private void RunCode(CompilerResults results)
        {
            Assembly executingAssembly = results.CompiledAssembly;
            try
            {
                //cant call the entry method if the assembly is null
                if (executingAssembly != null)
                {
                    object assemblyInstance = executingAssembly.CreateInstance("ExpressionEvaluator.Calculator");
                    //Use reflection to call the static Main function

                    Module[] modules = executingAssembly.GetModules(false);
                    Type[] types = modules[0].GetTypes();

                    //loop through each class that was defined and look for the first occurrance of the entry point method
                    foreach (Type type in types)
                    {
                        MethodInfo[] mis = type.GetMethods();
                        foreach (MethodInfo mi in mis)
                        {
                            if (mi.Name == "Calculate")
                            {
                                object result = mi.Invoke(assemblyInstance, null);
                                compileResult = result.ToString();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                compileMessage += "Error:  An exception occurred while executing the script";
            }

        }


        CodeMemberField FieldVariable(string fieldName, string typeName, MemberAttributes accessLevel)
        {
            CodeMemberField field = new CodeMemberField(typeName, fieldName);
            field.Attributes = accessLevel;
            return field;
        }

        CodeMemberField FieldVariable(string fieldName, Type type, MemberAttributes accessLevel)
        {
            CodeMemberField field = new CodeMemberField(type, fieldName);
            field.Attributes = accessLevel;
            return field;
        }

        private CompilerResults CompileAssembly()
        {
            // create a compiler
            ICodeCompiler compiler = CreateCompiler();
            // get all the compiler parameters
            CompilerParameters parms = CreateCompilerParameters();
            // compile the code into an assembly
            CompilerResults results = CompileCode(compiler, parms, _source.ToString());
            return results;
        }

        ICodeCompiler CreateCompiler()
        {
            //Create an instance of the C# compiler   
            CodeDomProvider codeProvider = null;
            codeProvider = new CSharpCodeProvider();
            ICodeCompiler compiler = codeProvider.CreateCompiler();
            return compiler;
        }

        CompilerParameters CreateCompilerParameters()
        {
            //add compiler parameters and assembly references
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.CompilerOptions = "/target:library /optimize";
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = false;
            compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");

            return compilerParams;
        }

        private CompilerResults CompileCode(ICodeCompiler compiler, CompilerParameters parms, string source)
        {
            //actually compile the code
            CompilerResults results = compiler.CompileAssemblyFromSource(
                                        parms, source);

            //Do we have any compiler errors?
            if (results.Errors.Count > 0)
            {
                foreach (CompilerError error in results.Errors)
                    compileMessage += error.ErrorText;
                return null;
            }
            return results;
        }

        void BuildClass(string expression)
        {
            // need a string to put the code into
            _source = new StringBuilder();
            StringWriter sw = new StringWriter(_source);

            //Declare your provider and generator
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeGenerator generator = codeProvider.CreateGenerator(sw);
            CodeGeneratorOptions codeOpts = new CodeGeneratorOptions();

            CodeNamespace myNamespace = new CodeNamespace("ExpressionEvaluator");
            myNamespace.Imports.Add(new CodeNamespaceImport("System"));
            myNamespace.Imports.Add(new CodeNamespaceImport("System.Windows.Forms"));

            //Build the class declaration and member variables			
            CodeTypeDeclaration classDeclaration = new CodeTypeDeclaration();
            classDeclaration.IsClass = true;
            classDeclaration.Name = "Calculator";
            classDeclaration.Attributes = MemberAttributes.Public;
            classDeclaration.Members.Add(FieldVariable("answer", typeof(string), MemberAttributes.Private));

            //default constructor
            CodeConstructor defaultConstructor = new CodeConstructor();
            defaultConstructor.Attributes = MemberAttributes.Public;
            defaultConstructor.Comments.Add(new CodeCommentStatement("Default Constructor for class", true));
            defaultConstructor.Statements.Add(new CodeSnippetStatement("//TODO: implement default constructor"));
            classDeclaration.Members.Add(defaultConstructor);

            //property
            classDeclaration.Members.Add(this.MakeProperty("Answer", "answer", typeof(string)));

            //Our Calculate Method
            CodeMemberMethod myMethod = new CodeMemberMethod();
            myMethod.Name = "Calculate";
            myMethod.ReturnType = new CodeTypeReference(typeof(string));
            myMethod.Comments.Add(new CodeCommentStatement("Calculate an expression", true));
            myMethod.Attributes = MemberAttributes.Public;
            myMethod.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression("Object obj"), new CodeSnippetExpression(expression)));
            myMethod.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression("Answer"), new CodeSnippetExpression("obj.ToString()")));
            myMethod.Statements.Add(
                           new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "Answer")));
            classDeclaration.Members.Add(myMethod);
            //write code
            myNamespace.Types.Add(classDeclaration);
            generator.GenerateCodeFromNamespace(myNamespace, sw, codeOpts);
            sw.Flush();
            sw.Close();
        }

        CodeMemberProperty MakeProperty(string propertyName, string internalName, Type type)
        {
            CodeMemberProperty myProperty = new CodeMemberProperty();
            myProperty.Name = propertyName;
            myProperty.Comments.Add(new CodeCommentStatement(String.Format("The {0} property is the returned result", propertyName)));
            myProperty.Attributes = MemberAttributes.Public;
            myProperty.Type = new CodeTypeReference(type);
            myProperty.HasGet = true;
            myProperty.GetStatements.Add(
                new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName)));

            myProperty.HasSet = true;
            myProperty.SetStatements.Add(
                new CodeAssignStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName),
                    new CodePropertySetValueReferenceExpression()));

            return myProperty;
        }

        string RefineEvaluationString(string eval)
        {
            // look for regular expressions with only letters
            Regex regularExpression = new Regex("[a-zA-Z_]+");

            // track all functions and constants in the evaluation expression we already replaced
            ArrayList replacelist = new ArrayList();

            // find all alpha words inside the evaluation function that are possible functions
            MatchCollection matches = regularExpression.Matches(eval);
            foreach (Match m in matches)
            {
                // if the word is found in the math member map, add a Math prefix to it
                bool isContainedInMathLibrary = _mathMembersMap[m.Value.ToUpper()] != null;
                if (replacelist.Contains(m.Value) == false && isContainedInMathLibrary)
                {
                    eval = eval.Replace(m.Value, "Math." + _mathMembersMap[m.Value.ToUpper()]);
                }

                // we matched it already, so don't allow us to replace it again
                replacelist.Add(m.Value);
            }

            // return the modified evaluation string
            return eval;
        }


        public void PrintComponents()
        {
            
        }

    }
}
