namespace Seda.TaskDistrubuter.Dal.Entities
{
    public class Personel
    {
        public int PersonelId { get; set; }
        public string Name { get; set; }

        public Rol Rol { get; set; }
    }
}
