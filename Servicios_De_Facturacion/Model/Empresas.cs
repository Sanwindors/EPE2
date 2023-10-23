public class Empresas{
    /*La addicion de un Id fue para la facilitacion dentro de la creacion de los HTTP 
    ya que por eleccion propia todos los rut fueron creados como un String y no como un int */
    public int id {get; set;}
    public string? Nombre_Empresa { get; set; }
    public string ?Rut_Empresa { get; set; }
    public string? Giro_Empresa { get; set; }
    public int Total_Ventas { get; set; }
    public int Monto_Ventas { get; set; }
    public int Monto_IVA{ get; set; }
    public int Monto_Utilidades { get; set; }
    public string? Nombre_Cliente { get; set; }
    public string? Apellidos_Cliente { get; set; }
    public int Edad_Cliente { get; set; }
    public string? Rut_Cliente { get; set; }

}
