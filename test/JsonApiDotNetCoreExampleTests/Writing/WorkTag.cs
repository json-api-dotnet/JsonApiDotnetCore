using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace JsonApiDotNetCoreExampleTests.Writing
{
    public sealed class WorkTag : Identifiable
    {
        [Attr]
        public string Text { get; set; }

        [Attr]
        public bool IsBuiltIn { get; set; }
    }
}
