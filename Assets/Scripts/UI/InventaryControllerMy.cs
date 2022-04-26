public class InventaryControllerMy
{
    private InventaryModelUI _inventoryModelUI;
    private readonly InventoryView _inventoryView;
    private ItemCollection _itemCollection;
    private bool showeMessage = false;
    private const int dely = 60;
    private const int _fullStack = 64;
    private int timerShoweMessage = dely;

    public InventaryControllerMy(InventaryModelUI inventoryModelUI, InventoryView inventoryView, ItemCollection itemCollection)
    {
        _inventoryModelUI = inventoryModelUI;
        _inventoryView = inventoryView;
        _itemCollection = itemCollection;
    }
    public void StartInventoryController()
    {
        foreach(var contein in _inventoryView.Contains)
        {
            contein.GetComponent<ContainsView>().free = true;
            contein.GetComponent<ContainsView>().containInventoryItem.id = 0;
            contein.GetComponent<ContainsView>().containInventoryItem.itemObject = null;
        }
    }
    public void AddItem(int id, int count)
    {
        foreach (var contein in _inventoryView.Contains)
        {
            if (id == contein.GetComponent<ContainsView>().containInventoryItem.id)
            {
                if ((contein.GetComponent<ContainsView>().count + count) < _fullStack)
                {
                    contein.GetComponent<ContainsView>().count += count;
                }
                else
                {
                    if (count < _fullStack)
                    {
                        count -= _fullStack - contein.GetComponent<ContainsView>().count;
                        contein.GetComponent<ContainsView>().full = true;
                    }

                }
            }
            else
            {
                if (contein.GetComponent<ContainsView>().free)
                {
                    contein.GetComponent<ContainsView>().containInventoryItem.id =id;
                    contein.GetComponent<ContainsView>().free = false;
                    contein.GetComponent<ContainsView>().containInventoryItem.itemObject = _itemCollection.itemSprite[id+1];
                    contein.GetComponent<ContainsView>().count += count;
                }
                else 
                {
                    MessageTextUi.SetMessage("Инвентарь полон");
                    showeMessage = true;
                }
            }
            contein.GetComponent<ContainsView>().SetTextCount();
        }
    }
    public void timerShowMessage()
    {
        if(showeMessage && timerShoweMessage>=0)
        {
            timerShoweMessage--;
        }
        if(timerShoweMessage<1)
        {
            showeMessage = false;
            timerShoweMessage = dely;
            MessageTextUi.ClearMessage();
        }
    }
}
