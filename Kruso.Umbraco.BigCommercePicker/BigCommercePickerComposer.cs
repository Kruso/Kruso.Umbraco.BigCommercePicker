using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Kruso.Umbraco.BigCommercePicker
{
    public class BigCommercePickerComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
           // builder.Components().Append<AddApiBaseUrl>();

            //composition.Register<ICommerceToolsService, CommerceToolsService>(Lifetime.Singleton);

            //composition.Components().Append<AddApiBaseUrl>();
        }
    }
}
