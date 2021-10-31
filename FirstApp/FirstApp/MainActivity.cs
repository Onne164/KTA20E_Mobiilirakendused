using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace FirstApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView answerTextView;
        EditText firstNumberEditText;
        EditText secondNumberEditText;
        Button addButton, subButton, mulButton, divButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            firstNumberEditText = FindViewById<EditText>(Resource.Id.editText1);
            secondNumberEditText = FindViewById<EditText>(Resource.Id.editText2);
            addButton = FindViewById<Button>(Resource.Id.addButton);
            answerTextView = FindViewById<TextView>(Resource.Id.answerTextView);
            addButton.Click += AddButton_Click;
            subButton = FindViewById<Button>(Resource.Id.subtractButton);
            subButton.Click += SubButton_Click;
            mulButton = FindViewById<Button>(Resource.Id.mulButton);
            mulButton.Click += MulButton_Click;
            divButton = FindViewById<Button>(Resource.Id.divButton);
            divButton.Click += DivButton_Click;

        }

        private void UpdateCalculatorText()
        {
            firstNumberEditText.Text = answerTextView.Text;
            secondNumberEditText.Text = null;
        }
        private void AddButton_Click(object sender, System.EventArgs e)
        {
            var firstNumber = double.Parse(firstNumberEditText.Text);
            var secondNumber = double.Parse(secondNumberEditText.Text);
            var answer = firstNumber + secondNumber;

            answerTextView.Text = answer.ToString();
           
            UpdateCalculatorText();
        }

        private void SubButton_Click(object sender, System.EventArgs e)
        {
            var firstNumber = double.Parse(firstNumberEditText.Text);
            var secondNumber = double.Parse(secondNumberEditText.Text);
            var answer = firstNumber - secondNumber;

            answerTextView.Text = answer.ToString();
            UpdateCalculatorText();
        }

        private void MulButton_Click(object sender, System.EventArgs e)
        {
            var firstNumber = double.Parse(firstNumberEditText.Text);
            var secondNumber = double.Parse(secondNumberEditText.Text);
            var answer = firstNumber * secondNumber;

            answerTextView.Text = answer.ToString();
            UpdateCalculatorText();
        }

        private void DivButton_Click(object sender, System.EventArgs e)
        {
            var firstNumber = double.Parse(firstNumberEditText.Text);
            var secondNumber = double.Parse(secondNumberEditText.Text);
            var answer = firstNumber / secondNumber;

            if (secondNumber==0)
            {
                answerTextView.Text = "0-ga ei saa jagada";
          
            } else { 

            answerTextView.Text = answer.ToString();
            }
            UpdateCalculatorText();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}