# Kruso.Umbraco.BigCommercePicker

BigCommerce product and category picker for Umbraco CMS.



## How to set up

* Add [nuget](https://www.nuget.org/packages/Kruso.Umbraco.BigCommercePicker/) to your Umbraco (v10+) project.
* Create an [API account in BigCommerce](https://support.bigcommerce.com/s/article/Store-API-Accounts?language=en_US). The API account needs *read-only* access to *Products*. <br>
The Access token for this account will be added to the Umbraco.BigCommercePicker configuration.<br>

### Configuration
It's possible to connect the BigCommerce picker to one or more BigCommerce stores (different store per language).


Sample configuration, added to `ConfigureServices` in `Startup.cs`:
``` 
services.AddBigCommercePicker(new List<BigCommerceServiceConfiguration>
{
    //add store used for en-US language
    new ()
    {
        LanguageCode = "en-US",
        StoreHash = "xd3iks453e",
        AuthToken = "5rs4rl0ibo54f2c7zht5bsdft3rk97r"
    }
    //add store for all other languages
    new ()
    {
        StoreHash = "zut2ikj1ae",
        AuthToken = "lx2jkul0ibo54f2c7zhtrl0ibo54fe"
    }
});
 ```       


## How to use
Add a BigCommerce picker to your content type. Note the configration that can be made when creating the editor (e.g. should this be a picker for products or categories?).


When rendering you can use the strongly typed collection
```
@foreach (Product product in Model.BigCommerceProducts)
{
    @(product.Name + " - " + product.Price)  <br/>
    @if (!string.IsNullOrEmpty(product.Images[0]?.UrlThumbnail))
    {
        <img src="@product.Images[0].UrlThumbnail" /> 
    }
    @foreach (Variant variant in product.Variants)
    {
       @if (!string.IsNullOrEmpty(variant.ImageUrl))
       {
           <img src="@variant.ImageUrl" /> 
       }
    }
}
```

More details are found [here](https://github.com/Kruso/Kruso.Umbraco.BigCommercePicker) .