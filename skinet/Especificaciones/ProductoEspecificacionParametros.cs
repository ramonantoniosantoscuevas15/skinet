namespace skinet.Especificaciones
{
    public class ProductoEspecificacionParametros
    {
        private const int MaximacatidadporPagina = 50;
        public int paginaIndex { get; set; } = 1;
        private int _Cantidadpagina = 5;

        public int CantidadPagina
        {
            get => _Cantidadpagina;
            set => _Cantidadpagina = (value > MaximacatidadporPagina) ? MaximacatidadporPagina : value; 
        }

        private List<string> _marcas = [];

		public List<string> marcas
		{
			get => _marcas;
			set 
			{
				_marcas = value.SelectMany(m => m.Split(',',StringSplitOptions.RemoveEmptyEntries)).ToList();
            }
		}

        private List<string> _tipos = [];

        public List<string> tipos
        {
            get => _tipos;
            set
            {
                _tipos = value.SelectMany(m => m.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
            }
        }
        public string? orden { get; set; }

        private string? _buscar;

        public string Buscar
        {
            get => _buscar ?? "";
            set => _buscar = value.ToLower();
        }


    }
}
