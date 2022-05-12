﻿function bigCommerceResource($q, $http, umbRequestHelper) {

    var getApiUrl = function (apiName, actionName, queryStrings) {
        //if (!Umbraco || !Umbraco.Sys || !Umbraco.Sys.ServerVariables || !Umbraco.Sys.ServerVariables["umbracoCommerceTools"]) {
        //    throw "No server variables defined!";
        //}

        //if (!Umbraco.Sys.ServerVariables["umbracoCommerceTools"][apiName]) {
        //    throw "No url found for api name " + apiName;
        //}

        //return Umbraco.Sys.ServerVariables["umbracoCommerceTools"][apiName] + actionName +
        //    (!queryStrings ? "" : "?" + (Utilities.isString(queryStrings) ? queryStrings : umbRequestHelper.dictionaryToQueryString(queryStrings)));

        return "/umbraco/backoffice/api/bigcomresource/" + actionName +
                (!queryStrings ? "" : "?" + (Utilities.isString(queryStrings) ? queryStrings : umbRequestHelper.dictionaryToQueryString(queryStrings)));
    };

    return {

        getByIds: function (ids, type, languageCode) {

            return umbRequestHelper.resourcePromise(
                $http.post(
                    getApiUrl(
                        "resourceApi",
                        "Get" + type + "ByIds"),
                        { ids: ids, languageCode }),
                'Failed to retrieve entity data for ids ' + ids);
        },

        search: function (terms, type, options) {

            var defaults = {
                pageSize: 20,
                pageNumber: 1,
                terms: terms,
                orderDirection: "asc",
                orderBy: "name"
            };
            if (options === undefined) {
                options = {};
            }
            //overwrite the defaults if there are any specified
            Utilities.extend(defaults, options);
            //now copy back to the options we will use
            options = defaults;

            return umbRequestHelper.resourcePromise(
                $http.get(
                    getApiUrl(
                        "resourceApi",
                        "GetPaged" + type,
                        options
                    )),
                'Failed to search entities for ' + terms);
        },

    };
}

angular.module('umbraco.resources').factory('bigCommerceResource', bigCommerceResource);