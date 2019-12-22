import com.codeborne.selenide.Configuration;
import static com.codeborne.selenide.Selectors.byText;
import static com.codeborne.selenide.Selenide.*;

public class AddInBasket {
    public void addInSteps() {
        Configuration.browser = ConfigFiles.baseBrowser;
        Configuration.baseUrl = "";

        open(ConfigFiles.urlForTests);
        $(byText(ConfigFiles.watchesForAddInBasket)).click();
        $(byText(ConfigFiles.addToCart)).click();
    }

    public boolean goodAdd() {
        int count = $(ConfigFiles.cartId).findElements(byText(ConfigFiles.goodAddInBasketText)).size();
        if (count > 0) {
            return true;
        } else {
            return false;
        }
    }
}
