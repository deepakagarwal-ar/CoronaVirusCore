class StoreCustomer {

    constructor(private firstName: string, private lastName: string) {

    }

    private ourName: string;

    set name(val) {
        this.ourName = val;
    }
    get name() {
        return this.ourName;
    }

    public showName() {
        alert(this.firstName + " " + this.lastName);
    }

}

