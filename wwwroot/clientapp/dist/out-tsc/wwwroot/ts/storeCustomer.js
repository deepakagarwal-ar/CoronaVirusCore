var StoreCustomer = /** @class */ (function () {
    function StoreCustomer(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }
    Object.defineProperty(StoreCustomer.prototype, "name", {
        get: function () {
            return this.ourName;
        },
        set: function (val) {
            this.ourName = val;
        },
        enumerable: true,
        configurable: true
    });
    StoreCustomer.prototype.showName = function () {
        alert(this.firstName + " " + this.lastName);
    };
    return StoreCustomer;
}());
//# sourceMappingURL=storeCustomer.js.map