function bigCommerceEntityTypePickerController($scope, eventsService) {
    // listen for changes, and emit event, to make the orderby picker update its options
    $scope.$watch("model.value", function (newVal, oldVal) {
        eventsService.emit("bigCommerce.entityTypeChanged");
    })
}

angular.module('umbraco').controller("Kruso.Umbraco.BigCommercePicker.PropertyEditors.EntityTypePickerController", bigCommerceEntityTypePickerController);