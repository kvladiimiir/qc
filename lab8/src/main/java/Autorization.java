import com.codeborne.selenide.Configuration;
import static com.codeborne.selenide.Selectors.byName;
import static com.codeborne.selenide.Selectors.byText;
import static com.codeborne.selenide.Selenide.*;

public class Autorization {
    public void autorizationSteps() {
        Configuration.browser = ConfigFiles.baseBrowser;
        Configuration.baseUrl = "";

        open(ConfigFiles.urlForTests);
        $(byText(ConfigFiles.accountLink)).click();
        $(byText(ConfigFiles.loginButton)).click();
        $(byName(ConfigFiles.loginName)).setValue(ConfigFiles.accountData);
        $(byName(ConfigFiles.passwordName)).setValue(ConfigFiles.accountData);
        $(ConfigFiles.loginId).find(byText(ConfigFiles.loginButton)).click();
    }

    public boolean goodAutorization() {
        return $(byText(ConfigFiles.goodAutorizationText)).isDisplayed();
    }
}
