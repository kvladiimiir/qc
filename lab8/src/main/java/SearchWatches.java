import com.codeborne.selenide.Configuration;

import static com.codeborne.selenide.Selectors.*;
import static com.codeborne.selenide.Selenide.*;

public class SearchWatches {
    public void searchSteps() {
        Configuration.browser = ConfigFiles.baseBrowser;
        Configuration.baseUrl = "";

        open(ConfigFiles.urlForTests);
        $(byName(ConfigFiles.searchName)).setValue(ConfigFiles.watchesForSearch).pressEnter();
    }

    public boolean goodSearch() {
        return $(byText(ConfigFiles.watchesForSearch)).isDisplayed();
    }
}
