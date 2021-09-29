namespace Popryzhenok_Subbotina.Models
{
    public partial class Agent
    {
        public override string ToString()
        {
            return Title;
        }

        public string LogoAgent => Logo == null ? "../../Images/picture.png" : "../.." + Logo;
    }
}