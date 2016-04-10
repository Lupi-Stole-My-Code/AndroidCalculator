using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndroidCalculator
{
    [Activity(Label = "AndroidCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnMC;
        Button btnMP;
        Button btnMM;
        Button btnMR;
        Button btnC;
        Button btnSign;
        Button btnDiv;
        Button btnMultiply;
        Button btn7;
        Button btn8;
        Button btn9;
        Button btnSubstract;
        Button btn4;
        Button btn5;
        Button btn6;
        Button btnAddition;
        Button btn1;
        Button btn2;
        Button btn3;
        Button btnCalc;
        Button btn0;
        Button btnDot;
        //Landscape only :
        Button btnSqrt;
        Button btnSquared;
        Button btnInvert;
        Button btnSin;
        Button btnCos;
        Button btnTan;
        TextView display;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            ///
            display = FindViewById<TextView>(Resource.Id.textView1);
            ///
            btnMC = FindViewById<Button>(Resource.Id.buttonClearMemory);
            btnMP = FindViewById<Button>(Resource.Id.buttonAddToMemory);
            btnMM = FindViewById<Button>(Resource.Id.buttonSubtractFromMemory);
            btnMR = FindViewById<Button>(Resource.Id.buttonRecallMemory);
            btnC = FindViewById<Button>(Resource.Id.buttonClear);
            btnSign = FindViewById<Button>(Resource.Id.buttonToggleSign);
            btnDiv = FindViewById<Button>(Resource.Id.buttonDivide);
            btnMultiply = FindViewById<Button>(Resource.Id.buttonMultiply);
            btn7 = FindViewById<Button>(Resource.Id.button7);
            btn8 = FindViewById<Button>(Resource.Id.button8);
            btn9 = FindViewById<Button>(Resource.Id.button9);
            btnSubstract = FindViewById<Button>(Resource.Id.buttonSubtract);
            btn4 = FindViewById<Button>(Resource.Id.button4);
            btn5 = FindViewById<Button>(Resource.Id.button5);
            btn6 = FindViewById<Button>(Resource.Id.button6);
            btnAddition = FindViewById<Button>(Resource.Id.buttonAdd);
            btn1 = FindViewById<Button>(Resource.Id.button1);
            btn2 = FindViewById<Button>(Resource.Id.button2);
            btn3 = FindViewById<Button>(Resource.Id.button3);
            btnCalc = FindViewById<Button>(Resource.Id.buttonEquals);
            btn0 = FindViewById<Button>(Resource.Id.button0);
            btnDot = FindViewById<Button>(Resource.Id.buttonDecimalPoint);
            //Landscape only
            btnSqrt = FindViewById<Button>(Resource.Id.buttonSquareRoot);
            btnSquared = FindViewById<Button>(Resource.Id.buttonSquared);
            btnInvert = FindViewById<Button>(Resource.Id.buttonInvert);
            btnSin = FindViewById<Button>(Resource.Id.buttonSine);
            btnCos = FindViewById<Button>(Resource.Id.buttonCosine);
            btnTan = FindViewById<Button>(Resource.Id.buttonTangent);
            //onClicks
            btn0.Click += Values_Click;
            btn1.Click += Values_Click;
            btn2.Click += Values_Click;
            btn3.Click += Values_Click;
            btn4.Click += Values_Click;
            btn5.Click += Values_Click;
            btn6.Click += Values_Click;
            btn7.Click += Values_Click;
            btn8.Click += Values_Click;
            btn9.Click += Values_Click;

            btnMC.Click += Operations_Click;
            btnMP.Click += Operations_Click;
            btnMM.Click += Operations_Click;
            btnMR.Click += Operations_Click;
            btnC.Click += Operations_Click;
            btnSign.Click += Operations_Click;
            btnDiv.Click += Operations_Click;
            btnMultiply.Click += Operations_Click;
            btnSubstract.Click += Operations_Click;
            btnAddition.Click += Operations_Click;
            btnDot.Click += Operations_Click;

            btnCalc.Click += Equals_Click;
            
            //Landscape
            if (btnSqrt != null)
            {
                btnSqrt.Click += Operations_Click;
                btnSquared.Click += Operations_Click;
                btnInvert.Click += Operations_Click;
                btnSin.Click += Operations_Click;
                btnCos.Click += Operations_Click;
                btnTan.Click += Operations_Click;
            }
        }

        private void Equals_Click(object sender, EventArgs e)
        {
            if (!Calc.validateDisplay(display.Text))
            {
                display.Text = "Invalid Data";
                return;
            }
            Button btn = (sender as Button);
            string comment = "";
            double result;
            double B = double.Parse(display.Text);
            bool val = Calc.getResult(B, out result, out comment);
            display.Text = result.ToString();
        }

        private void Values_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            if (display.Text == "0") display.Text = "";
            display.Text += btn.Text;
            if (!Calc.validateDisplay(display.Text))
            {
                display.Text = "Invalid Data";
                return;
            }
        }

        private void Operations_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            string op = btn.Text;
            if (!Calc.validateDisplay(display.Text) && op != "C")
            {
                display.Text = "Invalid Data";
                return;
            }
            switch (op)
            {
                case "+":
                    Calc.ExecAddition(double.Parse(display.Text));
                    display.Text = "0";
                    break;
                case "-":
                    Calc.ExecSubstraction(double.Parse(display.Text));
                    display.Text = "0";
                    break;
                case "/":
                    Calc.ExecDivision(double.Parse(display.Text));
                    display.Text = "0";
                    break;
                case "*":
                    Calc.ExecMultiplication(double.Parse(display.Text));
                    display.Text = "0";
                    break;
                case "x²":
                    display.Text = Calc.ExecEscalation(double.Parse(display.Text)).ToString();
                    break;
                case "√":
                    display.Text = Calc.ExecSquareRoot(double.Parse(display.Text)).ToString();
                    break;
                case ".":
                    try
                    {
                        string a = double.Parse(display.Text + ",0").ToString();
                        display.Text += ",";
                    }
                    catch
                    {
                        // do nothing
                    }
                    return;
                case "+/-":
                    display.Text = (double.Parse(display.Text) * -1.0).ToString();
                    break;
                case "C":
                    display.Text = "0";
                    Calc.reset();
                    break;
                case "MR":
                    display.Text = Calc.MemoryRecall().ToString();
                    break;
                case "MC":
                    Calc.MemoryClear();
                    break;
                case "M+":
                    Calc.MemoryAddTo(double.Parse(display.Text));
                    break;
                case "M-":
                    Calc.MemorySubTo(double.Parse(display.Text));
                    break;
                case "1/x":
                    display.Text = Calc.Invert(double.Parse(display.Text)).ToString();
                    break;
                case "sin":
                    display.Text = Calc.Sinus(double.Parse(display.Text)).ToString();
                    break;
                case "cos":
                    display.Text = Calc.Cosinus(double.Parse(display.Text)).ToString();
                    break;
                case "tan":
                    display.Text = Calc.Tangens(double.Parse(display.Text)).ToString();
                    break;
            }
        }

    }
}

