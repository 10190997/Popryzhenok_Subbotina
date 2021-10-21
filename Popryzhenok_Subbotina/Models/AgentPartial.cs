namespace Popryzhenok_Subbotina.Models
{
    public partial class Agent
    {
        public override string ToString()
        {
            return Title;
        }

        public string LogoAgent
        {
            get
            {
                return Logo ?? "../../Images/picture.png";
            }
            set { }
        }
    }
}