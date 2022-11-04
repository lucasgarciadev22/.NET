using quickmvvm;

namespace ListMVVM.Model
{
    public class Item : ObservableObject
    {
        //encapsulamento e uso da OnPropertyChanged para controlar os Bindings
        public int Id { get; set; }
        private string _itemName; public string ItemName {get {return _itemName;} set { _itemName = value; OnPropertyChanged(); } }
        private int _itemQtd; public int ItemQtd {get {return _itemQtd;} set { _itemQtd = value; OnPropertyChanged(); } }
        
        //impede criação de instâncias duplicadas
    public Item Clone()
    {
        return (Item)MemberwiseClone();
    }

    }
}
