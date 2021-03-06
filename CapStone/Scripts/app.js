

(function($){
    function addForm( e ){
        var dict = {
            Title : this["title"].value,
            Genre : this["genre"].value,
        	Director: this["director"].value
        };

        $.ajax({
            url: 'https://localhost:44365/',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ){
                $('#response pre').html( data );
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        });

        e.preventDefault();
    }

    $('#addForm').submit( addForm );

    


    function viewTable( e ){
        var dict = {
            MemberId: this["memberId"].value
        }

        $.ajax({
            url: 'https://localhost:44365/api/pharmacy/'+0,
            dataType: 'json',
            type: 'get',
            contentType: 'application/json',
            data: 1,
            success: function( data, textStatus, jQxhr ){
                $('#response pre').html( data );
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        }).then(function(data) {
            $('#detailsHeader').html('');
            $('#detailsTable').html('');
            $('#detailsHeader').append(
                "<tr>" +
                "<th> Title </th>" +
                "</tr>"
            );
            $.each(data, function(index, value){
                $('#movieTable').append(
                    "<tr>" +
                    
                    "<td>" + data.MemberId + "</td>" +
                    "<td>" + data.MemberLastName + "</td>" +
                    "<td>" + data.MemberMiddleInitial + "</td>" +
                    "<td>" + data.DateofBirth + "</td>" +
                    "<td>" + data.Gender + "</td>" +
                    "<td>" + data.FillDate + "</td>" +
                    "<td>" + data.ClaimStatus + "</td>" +
                    "<td>" + data.ClaimNumber + "</td>" +
                    "<td>" + data.OriginalClaimNumber + "</td>" +
                    "<td>" + data.PerscriptionNumber + "</td>" +
                    "<td>" + data.NDCCode + "</td>" +
                    "<td>" + data.DrugName + "</td>" +
                    "<td>" + data.OTCIndicator + "</td>" +
                    "<td>" + data.Multisource + "</td>" +
                    "<td>" + data.DEASchedule + "</td>" +
                    "<td>" + data.DiagnosisCode + "</td>" +
                    "<td>" + data.DWAIndecator + "</td>" +
                    "<td>" + data.DaysSupply + "</td>" +
                    "<td>" + data.BilledAmount + "</td>" +
                    "<td>" + data.PharmacyProviderID + "</td>" +
                    "<td>" + data.PrescribingProviderID + "</td>" +
                    "<td>" + data.RefillCode + "</td>" +
                    "<td>" + data.NCPDPrejectcodes + "</td>" +
                    "<td>" + data.NPI + "</td>" +
                    "<td>" + data.Last_Name + "</td>" +
                    "<td>" + data.First_Name + "</td>" +
                    "<td>" + data.Address + "</td>" +
                    "<td>" + data.City + "</td>" +
                    "<td>" + data.State + "</td>" +
                    "<td>" + data.Zip_Code + "</td>" +
                    "<td> <form id='viewDetails'> <input type='hidden' name='id' value =" + value.MemberId + " > <button type='submit'>Details</button> </form> </td>" + 
                    "</tr>"
                );
            });
            $('#viewDetails').submit( viewDetails );
        }
        )
        e.preventDefault();
    }

    $('#viewTable').submit( viewTable );

    
  
 
    


    function viewDetails( e ){
     
        var dict = {
            MemberId: this["memberId"].value
        }
        
        
        $.ajax({
            url: 'https://localhost:44365/api/pharmacy/'+ dict,
            dataType: 'json',
            type: 'edit',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ){
                $('#response pre').html( data );
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        }).then(function(data) {
            $('#detailsHeader').html('');
            $('#detailsTable').html('');
            $('#detailsHeader').append(
                "<tr>" +
                "<th> Title </th>" +
                "<th> Genre </th>" +
                "<th> Director </th>" +
                "</tr>"
            );
                $('#detailsTable').append(
                    "<tr>" +
                    "<td>" + data.Title + "</td>" +
                    "<td>" + data.MemberId + "</td>" +
                    "<td>" + data.MemberLastName + "</td>" +
                    "<td>" + data.MemberMiddleInitial + "</td>" +
                    "<td>" + data.DateofBirth + "</td>" +
                    "<td>" + data.Gender + "</td>" +
                    "<td>" + data.FillDate + "</td>" +
                    "<td>" + data.ClaimStatus + "</td>" +
                    "<td>" + data.ClaimNumber + "</td>" +
                    "<td>" + data.OriginalClaimNumber + "</td>" +
                    "<td>" + data.PerscriptionNumber + "</td>" +
                    "<td>" + data.NDCCode + "</td>" +
                    "<td>" + data.DrugName + "</td>" +
                    "<td>" + data.OTCIndicator + "</td>" +
                    "<td>" + data.Multisource + "</td>" +
                    "<td>" + data.DEASchedule + "</td>" +
                    "<td>" + data.DiagnosisCode + "</td>" +
                    "<td>" + data.DWAIndecator + "</td>" +
                    "<td>" + data.DaysSupply + "</td>" +
                    "<td>" + data.BilledAmount + "</td>" +
                    "<td>" + data.PharmacyProviderID + "</td>" +
                    "<td>" + data.PrescribingProviderID + "</td>" +
                    "<td>" + data.RefillCode + "</td>" +
                    "<td>" + data.NCPDPrejectcodes + "</td>" +
                    "<td>" + data.NPI + "</td>" +
                    "<td>" + data.Last_Name + "</td>" +
                    "<td>" + data.First_Name + "</td>" +
                    "<td>" + data.Address + "</td>" +
                    "<td>" + data.City + "</td>" +
                    "<td>" + data.State + "</td>" +
                    "<td>" + data.Zip_Code + "</td>" +
                    "</tr>"
                );
                $('#updateForm').submit( updateForm );
        }
        )
        e.preventDefault();
    }
    $('#viewDetails').submit( viewDetails );
    
 
    
    
   function update( e ){
           
       
       $.ajax({
           url: 'https://localhost:44365/api/pharmacy/',
           dataType: 'json',
           type: 'put',
           contentType: 'application/json',
           data: 1,
           success: function( data, textStatus, jQxhr ){
               $('#response pre').html( data );
           },
           error: function( jqXhr, textStatus, errorThrown ){
               console.log( errorThrown );
           }
       }).then(function(data) {
           $('#formTable').html('');
               $('tbody').append(
                "<tr>" +
               
                "<td>" + data.MemberId + "</td>" +
                "<td>" + data.MemberLastName + "</td>" +
                "<td>" + data.MemberMiddleInitial + "</td>" +
                "<td>" + data.DateofBirth + "</td>" +
                "<td>" + data.Gender + "</td>" +
                "<td>" + data.FillDate + "</td>" +
                "<td>" + data.ClaimStatus + "</td>" +
                "<td>" + data.ClaimNumber + "</td>" +
                "<td>" + data.OriginalClaimNumber + "</td>" +
                "<td>" + data.PerscriptionNumber + "</td>" +
                "<td>" + data.NDCCode + "</td>" +
                "<td>" + data.DrugName + "</td>" +
                "<td>" + data.OTCIndicator + "</td>" +
                "<td>" + data.Multisource + "</td>" +
                "<td>" + data.DEASchedule + "</td>" +
                "<td>" + data.DiagnosisCode + "</td>" +
                "<td>" + data.DWAIndecator + "</td>" +
                "<td>" + data.DaysSupply + "</td>" + 
                "<td>" + data.BilledAmount + "</td>" +
                "<td>" + data.PharmacyProviderID + "</td>" +
                "<td>" + data.PrescribingProviderID + "</td>" +
                "<td>" + data.RefillCode + "</td>" +
                "<td>" + data.NCPDPrejectcodes + "</td>" +
                "<td>" + data.NPI + "</td>" +
                "<td>" + data.Last_Name + "</td>" +
                "<td>" + data.First_Name + "</td>" +
                "<td>" + data.Address + "</td>" +
                "<td>" + data.City + "</td>" +
                "<td>" + data.State + "</td>" +
                "<td>" + data.Zip_Code + "</td>" +
                   "</tr>"
               );
       }
       )
       e.preventDefault();
   }
   $('#update').submit( update );

    function export(e) {


        $.ajax({
            url: 'https://localhost:44365/api/pharmacy/',
            dataType: 'json',
            type: 'put',
            contentType: 'application/json',
            data: 1,
            success: function (data, textStatus, jQxhr) {
                $('#response pre').html(data);
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        }).then(function (data) {
            $('#formTable').html('');
            $('tbody').append(
                "<tr>" +

                "<td>" + data.MemberId + "</td>" +
                "<td>" + data.MemberLastName + "</td>" +
                "<td>" + data.MemberMiddleInitial + "</td>" +
                "<td>" + data.DateofBirth + "</td>" +
                "<td>" + data.Gender + "</td>" +
                "<td>" + data.FillDate + "</td>" +
                "<td>" + data.ClaimStatus + "</td>" +
                "<td>" + data.ClaimNumber + "</td>" +
                "<td>" + data.OriginalClaimNumber + "</td>" +
                "<td>" + data.PerscriptionNumber + "</td>" +
                "<td>" + data.NDCCode + "</td>" +
                "<td>" + data.DrugName + "</td>" +
                "<td>" + data.OTCIndicator + "</td>" +
                "<td>" + data.Multisource + "</td>" +
                "<td>" + data.DEASchedule + "</td>" +
                "<td>" + data.DiagnosisCode + "</td>" +
                "<td>" + data.DWAIndecator + "</td>" +
                "<td>" + data.DaysSupply + "</td>" +
                "<td>" + data.BilledAmount + "</td>" +
                "<td>" + data.PharmacyProviderID + "</td>" +
                "<td>" + data.PrescribingProviderID + "</td>" +
                "<td>" + data.RefillCode + "</td>" +
                "<td>" + data.NCPDPrejectcodes + "</td>" +
                "<td>" + data.NPI + "</td>" +
                "<td>" + data.Last_Name + "</td>" +
                "<td>" + data.First_Name + "</td>" +
                "<td>" + data.Address + "</td>" +
                "<td>" + data.City + "</td>" +
                "<td>" + data.State + "</td>" +
                "<td>" + data.Zip_Code + "</td>" +
                "</tr>"
            );
        }
        )
        e.preventDefault();
    }
    $('#update').submit(Export);








   function updateForm( e ){
    
    var dict =  this["id"].value;

    console.log(dict);
    console.log(e);
    $.ajax({
        url: 'https://localhost:44365/api/pharmacy/'+ dict,
        dataType: 'json',
        type: 'get',
        contentType: 'application/json',
        data: JSON.stringify(dict),
        success: function( data, textStatus, jQxhr ){
            $('#response pre').html( data );
        },
        error: function( jqXhr, textStatus, errorThrown ){
            console.log( errorThrown );
        }
    }).then(function(data) {
        $('#detailsHeader').html('');
        $('#detailsTable').html('');
        $('#formTable').html('');
            $('#formTable').append(
            "<input type='hidden' name='id' value ="+data.MovieId+" > " +
            "<input type='text' name='title'/>" +
            "<input type='text' name='genre'/>" +
            "<input type='text' name='director'/>" +
            "<button type='submit'>Update</button>"
                
            );
            $('#formTable').submit( update );
    }
    )
    e.preventDefault();
}
$('#updateForm').submit( updateForm );

  



})(jQuery);




