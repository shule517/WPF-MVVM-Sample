using System.ComponentModel;
using WpfApplication.Command;

namespace WpfApplication
{
    class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            // コマンドの初期化
            PlusCommand = new PlusCommand();
            MinusCommand = new MinusCommand();
            MultiCommand = new MultiCommand();
            DivCommand = new DivCommand();

            // コマンド実行後の結果をResultに反映
            PlusCommand.PropertyChanged += (sender, e) =>
            {
                Result = ((PlusCommand)sender).Result.ToString();
                RaisePropertyChanged(e.PropertyName);
            };
            MinusCommand.PropertyChanged += (sender, e) =>
            {
                Result = ((MinusCommand)sender).Result.ToString();
                RaisePropertyChanged(e.PropertyName);
            };
            MultiCommand.PropertyChanged += (sender, e) =>
            {
                Result = ((MultiCommand)sender).Result.ToString();
                RaisePropertyChanged(e.PropertyName);
            };
            DivCommand.PropertyChanged += (sender, e) =>
            {
                Result = ((DivCommand)sender).Result;
                RaisePropertyChanged(e.PropertyName);
            };
        }

        // 四則演算コマンド
        public PlusCommand PlusCommand { get; private set; }
        public MinusCommand MinusCommand { get; private set; }
        public MultiCommand MultiCommand { get; private set; }
        public DivCommand DivCommand { get; private set; }

        // 入力A
        int inputA;
        public int InputA
        {
            get { return inputA; }
            set { inputA = value; RaisePropertyChanged("Input"); }
        }
        // 入力B
        int inputB;
        public int InputB
        {
            get { return inputB; }
            set { inputB = value; RaisePropertyChanged("Input"); }
        }
        // コマンドの引数用(入力Aと入力B)
        public int[] Input
        {
            get { return new int[] { inputA, inputB }; }
        }

        // 計算結果
        public string Result { get; set; }

        // プロパティ変更通知
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
