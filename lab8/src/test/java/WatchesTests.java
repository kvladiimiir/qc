import org.junit.Test;

import static org.junit.Assert.assertTrue;

public class WatchesTests {
    /* Авторизация */
    @Test
    public void Autorization_Test_ExpectedTrue() {
        /* arrange */
        Autorization autorization = new Autorization();
        /* act */
        autorization.autorizationSteps();
        /* assert */
        assertTrue(autorization.goodAutorization());
    }

    /* Добавление в корзину */
    @Test
    public void AddToCart_Test_ExpectedTrue() {
        /* arrange */
        AddInBasket addInBasket = new AddInBasket();
        /* act */
        addInBasket.addInSteps();
        /* assert */
        assertTrue(addInBasket.goodAdd());
    }

    /* Покупка товаров */
    @Test
        public void Checkout_Test_ExpectedTrue() {
        /* arrange */
        Checkout checkout = new Checkout();
        /* act */
        checkout.checkoutSteps();
        /* assert */
        assertTrue(checkout.goodCheckout());
    }

    /* Поиск товаров */
    @Test
    public void SearchWatches_Test_ExpectedTrue() {
        /* arrange */
        SearchWatches searchWatches = new SearchWatches();
        /* act */
        searchWatches.searchSteps();
        /* assert */
        assertTrue("Casio MRP-700-1AVEF not found", searchWatches.goodSearch());
    }
}
