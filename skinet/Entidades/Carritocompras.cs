namespace skinet.Entidades
{
    public class Carritocompras
    {
        public required string id { get; set; }
        public List<Carritoobjetos> objetos { get; set; } = [];
    }
}
