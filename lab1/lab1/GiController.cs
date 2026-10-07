using lab1;

public class GiController
{
    private readonly GiModel _model;
    public GiController(GiModel model) => _model = model;

    public void HandleSearch(string productName) => _model.SearchProduct(productName);
}