using Microsoft.AspNetCore.Mvc;

namespace KinoServerBackend.Model
{
    public class JavaScriptResult : ContentResult
    {
        public JavaScriptResult(string script) {
            this.Content = script;
            this.ContentType = "text/html";
        }
    }
}
