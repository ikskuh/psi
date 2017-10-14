﻿// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace CompilerKit {
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    using System.Collections.Generic;
    using System;
    
    
    public partial class TokenizerGenerator : TokenizerGeneratorBase {
        
        public virtual string TransformText() {
            this.GenerationEnvironment = null;
            
            #line 8 ""
            this.Write("using System;\nusing System.IO;\nusing System.Collections.Generic;\nusing System.Text.RegularExpressions;\nusing CompilerKit;\n\nsealed partial class ");
            
            #line default
            #line hidden
            
            #line 14 ""
            this.Write(this.ToStringHelper.ToStringWithCulture(TokenizerName));
            
            #line default
            #line hidden
            
            #line 14 ""
            this.Write(" : Tokenizer<");
            
            #line default
            #line hidden
            
            #line 14 ""
            this.Write(this.ToStringHelper.ToStringWithCulture(TokenType));
            
            #line default
            #line hidden
            
            #line 14 ""
            this.Write(">\n{\n\tpublic ");
            
            #line default
            #line hidden
            
            #line 16 ""
            this.Write(this.ToStringHelper.ToStringWithCulture(TokenizerName));
            
            #line default
            #line hidden
            
            #line 16 ""
            this.Write("(TextReader reader, string fileName) : this(reader, fileName, true)\n\t{\n\t\n\t}\n\n\tpublic ");
            
            #line default
            #line hidden
            
            #line 21 ""
            this.Write(this.ToStringHelper.ToStringWithCulture(TokenizerName));
            
            #line default
            #line hidden
            
            #line 21 ""
            this.Write("(TextReader reader, string fileName, bool closeOnDispose) : base(reader, fileName, closeOnDispose)\n\t{\n");
            
            #line default
            #line hidden
            
            #line 23 ""
 foreach(var tdef in Source) { 
            
            #line default
            #line hidden
            
            #line 24 ""
            this.Write("\t\tthis.RegisterToken(");
            
            #line default
            #line hidden
            
            #line 24 ""
            this.Write(this.ToStringHelper.ToStringWithCulture(TokenType));
            
            #line default
            #line hidden
            
            #line 24 ""
            this.Write(".");
            
            #line default
            #line hidden
            
            #line 24 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( tdef.Key ));
            
            #line default
            #line hidden
            
            #line 24 ""
            this.Write(", new Regex(@\"");
            
            #line default
            #line hidden
            
            #line 24 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( tdef.Value.ToString().Replace("\"", "\"\"") ));
            
            #line default
            #line hidden
            
            #line 24 ""
            this.Write("\", ");
            
            #line default
            #line hidden
            
            #line 24 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( MakeEnum(tdef.Value.Options) ));
            
            #line default
            #line hidden
            
            #line 24 ""
            this.Write("));\n");
            
            #line default
            #line hidden
            
            #line 25 ""
 } 
            
            #line default
            #line hidden
            
            #line 26 ""
            this.Write("\t\t\t\n\t\tthis.Initialize();\n\t}\n\n\tpartial void Initialize();\n\n\tprotected override Func<string,string> GetPostProcessor(");
            
            #line default
            #line hidden
            
            #line 32 ""
            this.Write(this.ToStringHelper.ToStringWithCulture(TokenType));
            
            #line default
            #line hidden
            
            #line 32 ""
            this.Write(" type)\n\t{\n\t\tswitch(type)\n\t\t{\n");
            
            #line default
            #line hidden
            
            #line 36 ""
 foreach(var step in Source.PostProcessings) { 
            
            #line default
            #line hidden
            
            #line 37 ""
            this.Write("\t\t\tcase ");
            
            #line default
            #line hidden
            
            #line 37 ""
            this.Write(this.ToStringHelper.ToStringWithCulture(TokenType));
            
            #line default
            #line hidden
            
            #line 37 ""
            this.Write(".");
            
            #line default
            #line hidden
            
            #line 37 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( step.Key ));
            
            #line default
            #line hidden
            
            #line 37 ""
            this.Write(":\n\t\t\t\treturn ");
            
            #line default
            #line hidden
            
            #line 38 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( step.Value ));
            
            #line default
            #line hidden
            
            #line 38 ""
            this.Write(";\n");
            
            #line default
            #line hidden
            
            #line 39 ""
 } 
            
            #line default
            #line hidden
            
            #line 40 ""
            this.Write("\t\t\tdefault:\n\t\t\t\treturn (text) => text;\n\t\t}\n\t}\n}\n\npublic enum ");
            
            #line default
            #line hidden
            
            #line 46 ""
            this.Write(this.ToStringHelper.ToStringWithCulture(TokenType));
            
            #line default
            #line hidden
            
            #line 46 ""
            this.Write("\n{\n");
            
            #line default
            #line hidden
            
            #line 48 ""
 foreach(var tdef in Source) { 
            
            #line default
            #line hidden
            
            #line 49 ""
            this.Write("\t");
            
            #line default
            #line hidden
            
            #line 49 ""
            this.Write(this.ToStringHelper.ToStringWithCulture( tdef.Key ));
            
            #line default
            #line hidden
            
            #line 49 ""
            this.Write(",\n");
            
            #line default
            #line hidden
            
            #line 50 ""
 } 
            
            #line default
            #line hidden
            
            #line 51 ""
            this.Write("}\n");
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        public virtual void Initialize() {
        }
    }
    
    public class TokenizerGeneratorBase {
        
        private global::System.Text.StringBuilder builder;
        
        private global::System.Collections.Generic.IDictionary<string, object> session;
        
        private global::System.CodeDom.Compiler.CompilerErrorCollection errors;
        
        private string currentIndent = string.Empty;
        
        private global::System.Collections.Generic.Stack<int> indents;
        
        private ToStringInstanceHelper _toStringHelper = new ToStringInstanceHelper();
        
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session {
            get {
                return this.session;
            }
            set {
                this.session = value;
            }
        }
        
        public global::System.Text.StringBuilder GenerationEnvironment {
            get {
                if ((this.builder == null)) {
                    this.builder = new global::System.Text.StringBuilder();
                }
                return this.builder;
            }
            set {
                this.builder = value;
            }
        }
        
        protected global::System.CodeDom.Compiler.CompilerErrorCollection Errors {
            get {
                if ((this.errors == null)) {
                    this.errors = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errors;
            }
        }
        
        public string CurrentIndent {
            get {
                return this.currentIndent;
            }
        }
        
        private global::System.Collections.Generic.Stack<int> Indents {
            get {
                if ((this.indents == null)) {
                    this.indents = new global::System.Collections.Generic.Stack<int>();
                }
                return this.indents;
            }
        }
        
        public ToStringInstanceHelper ToStringHelper {
            get {
                return this._toStringHelper;
            }
        }
        
        public void Error(string message) {
            this.Errors.Add(new global::System.CodeDom.Compiler.CompilerError(null, -1, -1, null, message));
        }
        
        public void Warning(string message) {
            global::System.CodeDom.Compiler.CompilerError val = new global::System.CodeDom.Compiler.CompilerError(null, -1, -1, null, message);
            val.IsWarning = true;
            this.Errors.Add(val);
        }
        
        public string PopIndent() {
            if ((this.Indents.Count == 0)) {
                return string.Empty;
            }
            int lastPos = (this.currentIndent.Length - this.Indents.Pop());
            string last = this.currentIndent.Substring(lastPos);
            this.currentIndent = this.currentIndent.Substring(0, lastPos);
            return last;
        }
        
        public void PushIndent(string indent) {
            this.Indents.Push(indent.Length);
            this.currentIndent = (this.currentIndent + indent);
        }
        
        public void ClearIndent() {
            this.currentIndent = string.Empty;
            this.Indents.Clear();
        }
        
        public void Write(string textToAppend) {
            this.GenerationEnvironment.Append(textToAppend);
        }
        
        public void Write(string format, params object[] args) {
            this.GenerationEnvironment.AppendFormat(format, args);
        }
        
        public void WriteLine(string textToAppend) {
            this.GenerationEnvironment.Append(this.currentIndent);
            this.GenerationEnvironment.AppendLine(textToAppend);
        }
        
        public void WriteLine(string format, params object[] args) {
            this.GenerationEnvironment.Append(this.currentIndent);
            this.GenerationEnvironment.AppendFormat(format, args);
            this.GenerationEnvironment.AppendLine();
        }
        
        public class ToStringInstanceHelper {
            
            private global::System.IFormatProvider formatProvider = global::System.Globalization.CultureInfo.InvariantCulture;
            
            public global::System.IFormatProvider FormatProvider {
                get {
                    return this.formatProvider;
                }
                set {
                    if ((value != null)) {
                        this.formatProvider = value;
                    }
                }
            }
            
            public string ToStringWithCulture(object objectToConvert) {
                if ((objectToConvert == null)) {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                global::System.Type type = objectToConvert.GetType();
                global::System.Type iConvertibleType = typeof(global::System.IConvertible);
                if (iConvertibleType.IsAssignableFrom(type)) {
                    return ((global::System.IConvertible)(objectToConvert)).ToString(this.formatProvider);
                }
                global::System.Reflection.MethodInfo methInfo = type.GetMethod("ToString", new global::System.Type[] {
                            iConvertibleType});
                if ((methInfo != null)) {
                    return ((string)(methInfo.Invoke(objectToConvert, new object[] {
                                this.formatProvider})));
                }
                return objectToConvert.ToString();
            }
        }
    }
}