namespace KR.Models
{
    public class MaskComboItem
    {
        public string Name { get; set; }
        public Image Image { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
