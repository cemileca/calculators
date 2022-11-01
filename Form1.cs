using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace Hesap_Makinesi
{
    //
    //((Regex.Matches(tiklananDugmeTekst, @"^[/*--+]+$").Count == 1)
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string _birinciRakam;

        bool _dortIslemTiklandiMi = false;
        char _eskiIslemIsareti=' ';
        char _yeniIslemIsarti=' ';
        double sonuc;
        private void TiklananRakam(object sender, EventArgs e)
        {
            _eskiIslemIsareti = _yeniIslemIsarti;
            _birinciRakam = ((Button)sender).Text;
            if (lblBirinciSatir.Text == "0")
            {
                lblBirinciSatir.Text = "";
            }
            if (_dortIslemTiklandiMi)
            {
                lblBirinciSatir.Text = "";
            }
            lblBirinciSatir.Text += _birinciRakam;

            _dortIslemTiklandiMi = false;
        }

        private void DortIslemdenBiriniYap(object sender, EventArgs e)
        {
            _yeniIslemIsarti = Convert.ToChar(((Button)sender).Text);

            if (_eskiIslemIsareti==' ')
            {
                _eskiIslemIsareti = _yeniIslemIsarti;
            }
           

            if (!_dortIslemTiklandiMi)
            {
              

                switch (_eskiIslemIsareti)
                {
                    case '+':  sonuc = sonuc + double.Parse(lblBirinciSatir.Text); break;
                    case '-':
                      
                        if (lblIkinciSatir.Text == "")
                        {
                            sonuc = double.Parse(lblBirinciSatir.Text);
                        }
                        else
                        {
                            sonuc = sonuc - double.Parse(lblBirinciSatir.Text);
                        }
                        break;
                    case '*':
                        if (lblIkinciSatir.Text=="")
                        {
                            sonuc = double.Parse(lblBirinciSatir.Text);
                        }
                        else
                        {
                            sonuc = sonuc * double.Parse(lblBirinciSatir.Text);
                        }
                        break;
                        sonuc = sonuc * double.Parse(lblBirinciSatir.Text); break;
                    case '/':
                        if (lblIkinciSatir.Text == "")
                        {
                            sonuc = double.Parse(lblBirinciSatir.Text);
                        }
                        else
                        {
                            sonuc = sonuc / double.Parse(lblBirinciSatir.Text); 

                        }
                        break;
                    default:
                        break;
                }
              
                lblBirinciSatir.Text = sonuc.ToString();
                lblIkinciSatir.Text = lblBirinciSatir.Text + " " + _yeniIslemIsarti;
            }
            else
            {
               
               

                lblIkinciSatir.Text = lblIkinciSatir.Text.Replace(_eskiIslemIsareti, _yeniIslemIsarti);
                _eskiIslemIsareti = _yeniIslemIsarti;
            }

           


            _dortIslemTiklandiMi = true;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            lblBirinciSatir.Text = "0";
            lblIkinciSatir.Text = "";
            _birinciRakam = "";
            _eskiIslemIsareti = ' ';
            _yeniIslemIsarti = ' ';
            sonuc = 0;
            _dortIslemTiklandiMi = false;
            _eskiIslemIsareti = ' ';
        }
    }
}