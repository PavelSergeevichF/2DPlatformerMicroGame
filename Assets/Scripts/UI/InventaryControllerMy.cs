public class InventaryControllerMy
{
    private InventaryModelUI _inventoryModelUI;
    private readonly InventoryView _inventoryView;
    private ItemCollection _itemCollection;
    private bool showeMessage = false;
    private const int dely = 60;
    private const int _fullStack = 64;
    private int timerShoweMessage = dely;
    private MessageTextUi _messageTextUi;

    public InventaryControllerMy(InventaryModelUI inventoryModelUI, InventoryView inventoryView, ItemCollection itemCollection, MessageTextUi messageTextUi)
    {
        _inventoryModelUI = inventoryModelUI;
        _inventoryView = inventoryView;
        _itemCollection = itemCollection;
        _messageTextUi = messageTextUi;
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
        for(int i=0;i< _inventoryView.Contains.Count;i++)
        {
            var contain = _inventoryView.Contains[i].GetComponent<ContainsView>();
            if (!contain.full)
            {
                if (id == contain.containInventoryItem.id)
                {
                    if ((contain.count + count) < _fullStack)
                    {
                        contain.count += count;
                        count = 0;
                        contain.SetTextCount();
                        return;
                    }
                    else
                    {
                        if (count < _fullStack)
                        {
                            count -= _fullStack - contain.count;
                            contain.full = true;
                        }
                    }
                }
                if (contain.free)
                {
                    contain.containInventoryItem.id = id;
                    contain.free = false;
                    if(id>0)
                    contain.spriteItem = _itemCollection.itemSprite[id-1].GetComponent<UnityEngine.SpriteRenderer>().sprite;
                    contain.GetComponent<UnityEngine.UI.Image>().sprite = contain.spriteItem;
                    contain.count += count;
                    count = 0;
                    contain.SetTextCount();
                    return;
                }
            }
            else 
            { 
                if(i>= _inventoryView.Contains.Count-1)
                {
                    _messageTextUi.SetMessage("Инвентарь полон");
                    showeMessage = true;
                }
            }
            contain.SetTextCount();
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
            _messageTextUi.ClearMessage();
        }
    }
    public void GetItem()
    { }
    public void Update()
    {
        if (UnityEngine.Input.GetButtonDown("Fire1"))
        {
            UnityEngine.Vector3 mousePos = UnityEngine.Input.mousePosition;
            {
                UnityEngine.Debug.Log(mousePos.x);
                UnityEngine.Debug.Log(mousePos.y);
            }
        }
    }
}
