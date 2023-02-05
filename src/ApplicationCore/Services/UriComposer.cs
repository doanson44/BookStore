using Microsoft.BookStore.ApplicationCore.Interfaces;

namespace Microsoft.BookStore.ApplicationCore.Services;

public class UriComposer : IUriComposer
{
    private readonly BookSettings _BookSettings;

    public UriComposer(BookSettings BookSettings) => _BookSettings = BookSettings;

    public string ComposePicUri(string uriTemplate)
    {
        return uriTemplate.Replace("http://BookBaseUrltobereplaced", _BookSettings.BookBaseUrl);
    }
}
