import com.codeborne.selenide.Configuration;
import static com.codeborne.selenide.Selectors.byText;
import static com.codeborne.selenide.Selenide.*;

public class Checkout {
    public void checkoutSteps() {
        Configuration.browser = ConfigFiles.baseBrowser;
        Configuration.baseUrl = "";
        open(ConfigFiles.urlForTests);
        $(byText(ConfigFiles.accountLink)).click();
        if (!$(byText(ConfigFiles.exit)).isDisplayed()) {
            open(ConfigFiles.urlForTests);
            Autorization autorization = new Autorization();
            autorization.autorizationSteps();
        }

        open(ConfigFiles.urlForTests);
        $(byText(ConfigFiles.watchesForAddInBasket)).click();
        $(byText(ConfigFiles.addToCart)).click();
        $(ConfigFiles.cartId).find(byText(ConfigFiles.checkoutText)).click();
        $(byText(ConfigFiles.checkoutButtonText)).click();
    }

    public boolean goodCheckout() {
        return $(byText(ConfigFiles.goodCheckoutText)).isDisplayed();
    }
}
