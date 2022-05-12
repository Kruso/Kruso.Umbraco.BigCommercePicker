using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;

namespace Kruso.Umbraco.BigCommercePicker.Editors
{
    [DataEditor(
        alias: BigCommercePickerConstants.PropertyEditors.PickerAlias,
        type: EditorType.PropertyValue | EditorType.MacroParameter,
        name: "BigCommerce picker",
        view: BigCommercePickerConstants.AppPluginFolderPath + "/PropertyEditors/BigCommercePicker.html",
        ValueType = ValueTypes.String,
        Group = Constants.PropertyEditors.Groups.Pickers,
        Icon = "icon-list")]
    public class BigCommercePicker : DataEditor
    {
        private readonly IIOHelper _ioHelper;
        //public Suggestions(IDataValueEditorFactory dataValueEditorFactory, IIOHelper ioHelper) : base(dataValueEditorFactory)

        //{
        //    _ioHelper = ioHelper;
        //}
        //protected override IConfigurationEditor CreateConfigurationEditor() => new SuggestionConfigurationEditor(_ioHelper);

        public BigCommercePicker(IDataValueEditorFactory dataValueEditorFactory, IIOHelper ioHelper) : base(dataValueEditorFactory)
        {
            _ioHelper = ioHelper;
        }

        protected override IConfigurationEditor CreateConfigurationEditor() => new BigCommercePickerConfigurationEditor(_ioHelper);
    }
}
