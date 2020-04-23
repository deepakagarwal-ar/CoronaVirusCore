import { browser, by, element } from 'protractor';
var AppPage = /** @class */ (function () {
    function AppPage() {
    }
    AppPage.prototype.navigateTo = function () {
        return browser.get(browser.baseUrl);
    };
    AppPage.prototype.getTitleText = function () {
        return element(by.css('app-root .content span')).getText();
    };
    return AppPage;
}());
export { AppPage };
//# sourceMappingURL=app.po.js.map