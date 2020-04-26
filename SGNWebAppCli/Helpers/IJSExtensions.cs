using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace SGNWebAppCli.Helpers
{
    public static class IJSExtensions
    {
        /// <summary>
        /// Before use need to install CSV helper from nuget packages
        /// this method need javaScript file in wwwroot folder with function named as first identifier e.x. saveAsFile

        public static async Task ToCsVFile(this IJSRuntime js, string nomberArch, byte[] array)
        {
            await js.InvokeVoidAsync("saveAsFile", nomberArch, Convert.ToBase64String(array));
        }
        /// <summary>
        /// Before use need to install itextSharp as provider to export file to PDF form
        /// this method need javaScript file in wwwroot folder with function named as first identifier saveAsFile
        public static async Task ToPdfFile(this IJSRuntime js, string fileName, byte[] array)
        {
            await js.InvokeVoidAsync("saveAsFile", fileName, Convert.ToBase64String(array));
        }
    }
}
