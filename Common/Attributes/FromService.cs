using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Common.Attributes
{
    public class FromService : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource => BindingSource.Services;
    }
}
