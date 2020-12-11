namespace JsonApiDotNetCore.Controllers.Annotations
{
    /// <summary>
    /// Used on an ASP.NET Core controller class to indicate write actions must be blocked.
    /// </summary>
    /// <example><![CDATA[
    /// [HttpReadOnly]
    /// public class ArticlesController : BaseJsonApiController<Article>
    /// {
    /// }
    /// ]]></example>
    public sealed class HttpReadOnlyAttribute : HttpRestrictAttribute
    {
        protected override string[] Methods { get; } = { "POST", "PATCH", "DELETE" };
    }
}