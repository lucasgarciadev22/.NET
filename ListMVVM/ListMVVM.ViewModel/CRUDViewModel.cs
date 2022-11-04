using ListMVVM.Model;
using ListMVVM.Repository;
using ListMVVM.Service;
using quickmvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ListMVVM.ViewModel
{
    #region Classes
    public class CRUDViewModel : ObservableObject, IViewModel
    {
        #region Variables
        //definindo melhor as instâncias privadas e públicas
        MainViewModel _mainViewModel;

        private readonly ItemService itemService = new ItemService();

        public int SelectedIndex = 0;

        private ObservableCollection<Item> _allItems; public ObservableCollection<Item> AllItems { get { return _allItems; } set { _allItems = value; OnPropertyChanged(); } }
        private Item _selectedItem; public Item SelectedItem { get { return _selectedItem; } set { _selectedItem = value; OnPropertyChanged(); } }
        private Item _configItem; public Item ConfigItem { get { return _configItem; } set { _configItem = value; OnPropertyChanged(); } }
        private string _filteredItemName; public string FilteredItemName { get { return _filteredItemName; } set { _filteredItemName = value; OnPropertyChanged(); } }

        private string _buttonText; public string ButtonText { get { return _buttonText; } set { _buttonText = value; OnPropertyChanged(); } }
        private string _buttonColor; public string ButtonColor { get { return _buttonColor; } set { _buttonColor = value; OnPropertyChanged(); } }
        private string _toolTipText; public string ToolTipTxt { get { return _toolTipText; } set { _toolTipText = value; OnPropertyChanged(); } }
        private string _toolTipIcon; public string ToolTipIcon { get { return _toolTipIcon; } set { _toolTipIcon = value; OnPropertyChanged(); } }
        private bool _edit = false; public bool Edit { get { return _edit; } set { _edit = value; OnPropertyChanged(); } }
        private bool _remove = false; public bool Remove { get { return _remove; } set { _remove = value; OnPropertyChanged(); } }

        ItemRepository itemRepository = new ItemRepository();

        IList<Item> filtered = new List<Item>();
        #endregion

        public CRUDViewModel() { }

        //cria um novo CRUDViewModel(arg), passando um novo MainViewModel para editar os conteúdos da MainView
        public CRUDViewModel(MainViewModel mainView)
        {
            //definindo os repositórios
            //nova mainView
            _mainViewModel = mainView;
            //criando nova lista de itens 
            AllItems = new ObservableCollection<Item>();
            ConfigItem = new Item();
            //definindo conteúdo do botão de ação inicial
            ButtonText = "ADICIONAR";
            ButtonColor = "DarkSlateBlue";
            ToolTipTxt = "Clique para adicionar um item à lista";
            ToolTipIcon = "FilePlus";
            ////torna o botão cancelar oculto
            ButtonVisibilityOn();
            TimerConfig();

            GetItemList();
        }
        #endregion

        #region Event Handlers
        public ICommand CloseThisControl_ClickCommand => new DelegateCommand(CloseThisControl);
        public ICommand AddItem_ClickCommand => new DelegateCommand(AddItem);
        public ICommand EditItem_ClickCommand => new DelegateCommand(EditItem);
        public ICommand RemoveItem_ClickCommand => new DelegateCommand(RemoveItem);
        public ICommand CalcelItem_ClickCommand => new DelegateCommand(CalcelItem);
        public ICommand FilterItem_ClickCommand => new DelegateCommand(FilterItem);


        private Visibility _visibility; public Visibility Visibility { get { return _visibility; } set { _visibility = value; OnPropertyChanged(); } }
        DispatcherTimer _addStatus = new DispatcherTimer();
        #endregion

        #region Methods
        //imprementando métodos

        public void ButtonVisibilityOn()
        {
            Visibility = Visibility.Visible;
        }

        public void ButtonVisibilityOff()
        {
            Visibility = Visibility.Hidden;
        }

        public void CloseThisControl(object parameter)
        {
            _mainViewModel.ClearScreen();
        }

        async void GetItemList()
        {
            await Task.Run(() => { AllItems = new ObservableCollection<Item>(itemService.FindAll()); });
        }

        async void FilterItem(object parameter)
        {
            if (FilteredItemName == "" || FilteredItemName == null)
            {
                GetItemList();
            }
            else
            {
            filtered = itemRepository.FindByItemName(FilteredItemName);

            await Task.Run(() => { AllItems = new ObservableCollection<Item>(filtered); });
            }
        }


        void EditItem(object parameter)
        {
            try
            {
                if (SelectedItem != null && _remove == false)
                {
                    ButtonText = "CONFIRMAR EDIÇÃO";
                    ButtonColor = "DarkSlateBlue";
                    ToolTipTxt = "Clique para editar o item selecionado";
                    ToolTipIcon = "FileEdit";
                    //habilita edição
                    _edit = true;
                    _remove = false;
                    Remove = false;
                    ////torna o botão cancelar visível
                    ButtonVisibilityOn();
                    //carrega as informações do item selecionado para os campos de edição
                    ConfigItem = SelectedItem;
                }
            }
            catch (Exception)
            {
                _mainViewModel.TitleState = "Não foi possível editar este Item. Tente novamente!";
                _mainViewModel.Icon = "CheckboxBlankOff";
            }
        }

        void RemoveItem(object parameter)
        {
            try
            {
                if (SelectedItem != null && _edit == false)
                {
                    ButtonText = "CONFIRMAR REMOÇÃO";
                    ButtonColor = "IndianRed";
                    ToolTipTxt = "Clique para remover o item selecionado";
                    ToolTipIcon = "FileRemove";

                    //habilita remoção
                    _remove = true;
                    Remove = true;
                    _edit = false;
                    ////torna o botão cancelar visível
                    ButtonVisibilityOn();
                    //carrega os campos com item selecionado
                    ConfigItem = SelectedItem;
                    //SelectedIndex = AllItems.IndexOf(SelectedItem);
                }
            }
            catch (Exception)
            {
                _mainViewModel.TitleState = "Não foi possível remover este Item. Tente novamente!";
                _mainViewModel.Icon = "CheckboxBlankOff";
            }
        }

        void CalcelItem(object parameter)
        {
            SelectedItem = null;
            ConfigItem = new Item();
            ButtonText = "ADICIONAR";
            ToolTipTxt = "Clique para adicionar um item à lista";
            ToolTipIcon = "FilePlus";
            _edit = false;
            _remove = false;
            Remove = false;
            _mainViewModel.TitleState = "Ação cancelada!";
            _mainViewModel.Icon = "CheckboxBlankOff";
            _addStatus.Start();

        }

        void TimerConfig()
        {
            _addStatus.Interval = TimeSpan.FromSeconds(4);
            _addStatus.Tick += SetDefaultStatusMsg;
        }

        void SetDefaultStatusMsg(object sender, EventArgs e)
        {
            _mainViewModel.TitleState = "Visualizando CRUD";
            _mainViewModel.Icon = "FormSelect";
            _addStatus.Stop();
        }

        private void AddItem(object parameter)
        {
            try
            {
                if (_edit)
                {
                    //edita item específico na lista AllItems usando método clone
                    itemService.SaveOrUpdate(ConfigItem);
                    ConfigItem = new Item();
                    SelectedItem = null;
                    GetItemList();
                    _edit = false;
                    //exibe mensagem no statusbar
                    _mainViewModel.TitleState = "Item editado com sucesso!";
                    _mainViewModel.Icon = "CheckboxMarked";
                }
                else if (_remove)
                {
                    //AllItems.RemoveAt(SelectedIndex);
                    itemService.Delete(ConfigItem);

                    ConfigItem = new Item();
                    SelectedItem = null;
                    GetItemList();
                    _remove = false;
                    _mainViewModel.TitleState = "Item removido com sucesso!";
                    _mainViewModel.Icon = "CheckboxMarked";

                    //exibe mensagem no statusbar
                }
                else
                {
                    //criar novo item na lista AllItems usando método clone
                    //AllItems.Add(ConfigItem.Clone());
                    itemService.SaveOrUpdate(ConfigItem);
                    ConfigItem = new Item();
                    GetItemList();
                    //exibe mensagem no statusbar
                    _mainViewModel.TitleState = "Item adicionado com sucesso!";
                    _mainViewModel.Icon = "CheckboxMarked";
                }

                //updating list
                GetItemList();

                ButtonColor = "DarkSlateBlue";
                ButtonText = "ADICIONAR";
                ToolTipTxt = "Clique para adicionar um item à lista";
                ToolTipIcon = "FilePlus";

                _addStatus.Start();
            }
            catch (Exception e)
            {
                _mainViewModel.TitleState = "Não foi possível completar a ação. Tente novamente!";
                _mainViewModel.Icon = "CheckboxBlankOff";
            }
        }
        #endregion
    }
}

