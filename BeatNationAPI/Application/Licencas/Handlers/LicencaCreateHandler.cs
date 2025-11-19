
using BeatNationAPI.Application.Command.Licencas.Response;
using BeatNationAPI.Application.Licencas.Command.Request;
using BeatNationAPI.Common.Responses;
using BeatNationAPI.Data;
using BeatNationAPI.Models;
using FluentValidation;
using MediatR;


namespace BeatNationAPI.Application.Handlers
{
    public class LicencaCreateHandler :
     IRequestHandler<LicencaCreateRequest, Response<LicencaCreateResponse>>
    {
        private readonly AppDbContext _context;
        private readonly IValidator<LicencaCreateRequest> _validator;



        public LicencaCreateHandler(AppDbContext context, IValidator<LicencaCreateRequest> validator)
        {
            _context = context;
            _validator = validator;

        }

        public async Task<Response<LicencaCreateResponse>> Handle(LicencaCreateRequest request, CancellationToken cancellationToken)
        {
            // Valida o request

            // 🔍 Validação manual
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Response<LicencaCreateResponse>.Fail("Falha na validação" + errors);
            }


            Licenca licencas = request;
            licencas.Id = Guid.NewGuid();
            //trocar quando implementar requisições via token

            if (licencas == null)
            {
                return Response<LicencaCreateResponse>.Fail("Não foi possível criar a licença, tente mais tarde");
            }

            // Salva no banco
            _context.Licencas.Add(licencas);
            await _context.SaveChangesAsync(cancellationToken);



            return Response<LicencaCreateResponse>.Ok(licencas, "Licença criado com sucesso !");

        }
    }


}