# Kruso.Umbraco.BigCommercePicker

BigCommerce product and category picker for Umbraco CMS.


## How to install

* Add [nuget](https://www.nuget.org/packages/Kruso.Umbraco.BigCommercePicker/) to your Umbraco 9 project.
* Create an API account in BigCommerce. The API account needs read-only access to Products. <br>
The Access token for this account will be added to the Umbraco.BigCommercePicker configuration.<br>
TODO: image.

### Configuration
It's possible to connect the BigCommerce picker to one or more BigCommerce stores (different store per language).
<br>TODO: describe more<br><br>
Sample configuration, added to `ConfigureServices` in `Startup.cs`:
``` 
services.AddBigCommercePicker(new List<BigCommerceServiceConfiguration>
{
    new ()
    {
        StoreHash = "zut2ikj1ae",
        AuthToken = "lx2jkul0ibo54f2c7zht5bqj4xqyom2"
    }
});
 ```       


## How to use
Add a BigCommerce picker to your content type. Note the configration that can be made when creating the editor (e.g. should this be a picker for products or categories?).
<br><br>
When rendering you can use the strongly typed collection



## Roadmap
* Show product brand when selecting products to help editor select correct product.
* Show product categories when selecting products to help editor select correct product.
* Possible to set number of items that are allowed to be selected by editor.
* Possible to set sort order for the selected products/categories.
