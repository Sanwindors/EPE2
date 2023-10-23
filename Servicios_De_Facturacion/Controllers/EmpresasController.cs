using Microsoft.AspNetCore.Mvc;

[ApiController]

public class Empresa : ControllerBase{

    public Empresas[] DatosEmpresas = new Empresas[]{
        new Empresas {
            id=1,
            Nombre_Empresa="Ideal",
            Rut_Empresa="12345678-9",
            Giro_Empresa="Venta1",
            Total_Ventas=300,
            Monto_Ventas=3000000,
            Monto_IVA = 570000,
            Monto_Utilidades=2429700,
            Nombre_Cliente="Juan",
            Apellidos_Cliente="Castillo",
            Edad_Cliente=56,
            Rut_Cliente="12235064-5",
        },
                new Empresas {
            id=2,
            Nombre_Empresa="Castaño",
            Rut_Empresa="23456789-1",
            Giro_Empresa="Venta1",
            Total_Ventas=300,
            Monto_Ventas=3000000,
            Monto_IVA = 570000,
            Monto_Utilidades=2429700,
            Nombre_Cliente="Pedro",
            Apellidos_Cliente="Lillo",
            Edad_Cliente=81,
            Rut_Cliente="5615891-k"
        },
                new Empresas {
            id=3,
            Nombre_Empresa="Fuchs",
            Rut_Empresa="34567891-2",
            Giro_Empresa="Venta1",
            Total_Ventas=300,
            Monto_Ventas=3000000,
            Monto_IVA = 570000,
            Monto_Utilidades=2429700,
            Nombre_Cliente="Ivan",
            Apellidos_Cliente="Arce",
            Edad_Cliente=61,
            Rut_Cliente="5644921-2"
        },
                new Empresas {
            id=4,
            Nombre_Empresa="The Coca-Cola Company",
            Rut_Empresa="45678912-3",
            Giro_Empresa="Venta1",
            Total_Ventas=300,
            Monto_Ventas=3000000,
            Monto_IVA = 570000,
            Monto_Utilidades=2429700,
            Nombre_Cliente="John",
            Apellidos_Cliente="Kenedy",
            Edad_Cliente=49,
            Rut_Cliente="1365889-2",
        },
                new Empresas {
            id=5,
            Nombre_Empresa="Adidas",
            Rut_Empresa="56789123-4",
            Giro_Empresa="Venta1",
            Total_Ventas=300,
            Monto_Ventas=3000000,
            Monto_IVA = 570000,
            Monto_Utilidades=2429700,
            Nombre_Cliente="Esteban",
            Apellidos_Cliente="Castro",
            Edad_Cliente=60,
            Rut_Cliente="1584568-7",
        }
    };
    /*Este Metodo tiene la intencion de mostar los 3 primeros registros, esto es posible gracias 
    a ".Take(*).ToArray() donde * representa los registros que se quieran mostrar"*/
    [HttpGet]
    [Route("3-Empresas")]
    public IActionResult Listar3(){
        try{
            if (DatosEmpresas != null && DatosEmpresas.Length >= 3)
            {
                var primerosTresClientes = DatosEmpresas.Take(3).ToArray();
                return StatusCode(200, primerosTresClientes);
            }else{
                return StatusCode(404,"No se encontraron los datos");
            }
        }catch(Exception){ 
            return StatusCode(401,"No se encontraron los datos");
        }
      
    }
    /*En este metodo se ocupo la implementacion de los Id para facilitar la busquedas dentro del Swagger,
    la idea es simple con solo el id para buscar este metodo arroja todos los datos solicitados*/
    [HttpGet]
    [Route("Buscar Empresa/{id}")]
    public IActionResult BuscarRut(int id)
    {
        try
        {
            if (id > 0 && id < DatosEmpresas.Length)
            {
                return StatusCode(200, DatosEmpresas[id-1]);
            }
            else
            {
                return StatusCode(404, "No se encontraron los datos");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error interno: " + ex);
        }
    }
    /*Este metodo permite la creacion de nuevos regristos donde se tiene que rellenar cada espacio 
    entregado para la creacion final de un nuevo registro*/
    [HttpPost]
    [Route("Crear Empresa")]

    public IActionResult CrearE([FromBody]Empresas empresas){
        try{
            return StatusCode(200,DatosEmpresas);
        }catch(Exception ex){
            return StatusCode(400,"No se puede crear la Empresa por: "+ ex);
        }
    }
    /*Al igual que con el Segundo metodo la busqueda se realiza a traves del id inventado para la 
    facil edicion, donde cada parametro solicitado puede ser o no editado por un tercero*/
    [HttpPut]
    [Route("CambiarEmpresa/{id}")]
    public IActionResult EditarE(int id, [FromBody] Empresas empresas)
    {
        try
        {
            if (id > 0 && id == empresas.id)
            {
                DatosEmpresas[id-1].id = empresas.id;
                DatosEmpresas[id-1].Nombre_Empresa = empresas.Nombre_Empresa;
                DatosEmpresas[id-1].Rut_Empresa = empresas.Rut_Empresa;
                DatosEmpresas[id-1].Giro_Empresa = empresas.Giro_Empresa;
                DatosEmpresas[id-1].Total_Ventas = empresas.Total_Ventas;
                DatosEmpresas[id-1].Monto_Ventas = empresas.Monto_Ventas;
                DatosEmpresas[id-1].Monto_IVA = empresas.Monto_IVA;
                DatosEmpresas[id-1].Monto_Utilidades = empresas.Monto_Utilidades;
                DatosEmpresas[id-1].Nombre_Cliente=empresas.Nombre_Cliente;
                DatosEmpresas[id-1].Apellidos_Cliente=empresas.Apellidos_Cliente;
                DatosEmpresas[id-1].Edad_Cliente=empresas.Edad_Cliente;
                DatosEmpresas[id-1].Rut_Cliente=empresas.Rut_Cliente;

                return StatusCode(200, DatosEmpresas[id-1]);
            }
            else
            {
                return StatusCode(404, "Empresa no encontrada");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error en el servidor por: " + ex);
        }
    }
    /*Al igual que el anterior el eliminacion de los registros es atraves de los id para la facil 
    manipulacion de estos*/
    [HttpDelete]
    [Route("Borrar Empresa/{id}")]
    public IActionResult BorrarE(int id){
        try{
            if(id > 0 && id <= DatosEmpresas.Length){
                DatosEmpresas[id-1]= null;
                return StatusCode(200,"Se elimino la empresa");
            }else{
                return StatusCode(401,"No se puede borrar la empresa por que no existe");
            }
        }catch(Exception ex){
            return StatusCode(500,"No se pudo borrar por: "+ ex);
        }
    }

}
