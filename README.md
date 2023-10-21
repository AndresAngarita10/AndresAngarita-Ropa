# AndresAngarita-Ropa
 ###Consulta 1 :
  
    **Método**: `GET`
    **Endpoint**: `http://localhost:5272/api/Proveedor/consulta1`
  ###consulta 2 :
  
    **Método**: `GET`
    **Endpoint**: `http://localhost:5272/api/orden/consulta2/1`
  ###consulta 3 :

    **Método**: `GET`
    **Endpoint**: `http://localhost:5272/api/TipoProteccion/consulta3`
  ###consulta 4 :

    **Método**: `GET`
    **Endpoint**: `http://localhost:5272/api/orden/consulta4/1`
  ###consulta 5 :

    **Método**: `GET`
    **Endpoint**: `http://localhost:5272/api/InsumoPrenda/consulta5/1`
    {
    	"Name":"No Definido"
    }
  ###Tabla Laboratory :

    **Método**: `GET`
    **Endpoint**: `http://localhost:5021/api/Laboratory`
    {
    	"Name":"Genfares",
    	"Address":"calle aa con bbb",
    	"Phone":"123456"
    }
  ###Tabla Medicine :

    **Método**: `GET`
    **Endpoint**: `http://localhost:5021/api/Medicine`
    {
    	"Name":"Terramicina",
    	"QuantityAvalible":50,
    	"Price":10.99,
    	"LaboratoryIdFk":1
    }
  ###Tabla Partner :

    **Método**: `GET`
    **Endpoint**: `http://localhost:5021/api/Partner`
    {	
      "Name":"Carlos camilo",
    	"Email":"calos@a.com",
    	"Phone":"3005669",
    	"Address":"calle re falsa 123",
    	"SpecialtyIdFk":11,
    	"GenderIdFk":1,
    	"PartnerTypeIdFk":2
    }
  ###Tabla Pet :


    **Método**: `POST`
    **Endpoint**: `http://localhost:5021/api/Pet`
    {
      "Name":"Carlos camilo pet",
      "DateBirth":"2022-01-15",
      "UserOwnerId":14,
      "SpeciesIdFk":2,
      "BreedIdFk":1
    }
  ###Tabla Quote :

    **Método**: `POST`
    **Endpoint**: `http://localhost:5021/api/Quote`
    {
    	"Hour":"15:30:00",
    	"Date":"2022-01-15",
    	"Reason":"asmndfbksafdlkusahdf",
    	"PetIdFk":2,
    	"VeterinarianIdFk":1
    }
  ###Tabla MedicinePartner :

    **Método**: `POST`
    **Endpoint**: `http://localhost:5021/api/MedicinePartner`
    {
    	"MedicineIdFk":18,
    	"PartnerIdFk":4
    }
  ###Tabla MedicalTreatment :

    **Método**: `POST`
    **Endpoint**: `http://localhost:5021/api/MedicalTreatment`
    {
    	"DateStartTreatment":"2022-01-15",
    	"QuoteIdFk":8
    }
