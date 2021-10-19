using Billing.Data;
using Billing.Data.Contracts;
using Billing.Data.Models.Entities;
using Billing.Data.Queries.QueryBuilders;
using Billing.Infrastructure.Configuration;
using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Implementations;
using Billing.Infrastructure.Implementations.DataProviders;
using Billing.Infrastructure.Implementations.Mappers;
using Billing.Infrastructure.Implementations.PaymentGateways;
using Billing.Infrastructure.Models.BillingUsers;
using Billing.Infrastructure.Models.Enums;
using Billing.Infrastructure.Models.Orders;
using Billing.Infrastructure.Models.Orders.Receipts;
using Billing.Infrastructure.Models.Orders.RequestData;
using Billing.Infrastructure.Models.Payments;
using Billing.Infrastructure.Models.Products;
using Billing.Infrastructure.Validators.Orders;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BillingDbContext>(opt => opt.UseInMemoryDatabase("BillingDB"));
            services.AddScoped<IQueryBuilder<BillingUser>, BillingUserQueryBuilder>();
            services.AddScoped<IQueryBuilder<Order>, OrderQueryBuilder>();

            var billingApiConfiguration = configuration
                .GetSection(nameof(BillingApiConfiguration))
                .Get<BillingApiConfiguration>(binderOptions => binderOptions.BindNonPublicProperties = true);
            services.AddScoped<IBillingApiConfiguration>(services => billingApiConfiguration);


            services.AddScoped<AbstractValidator<OrderRequestData>, OrderRequestDataValidator>();

            services.AddScoped<MasterCardPaymentGateway>();
            services.AddScoped<PaypalPaymentGateway>();
            services.AddScoped<VisaPaymentGateway>();
            services.AddScoped<Func<PaymentProvider, IDataTarget<Payment>>>(services =>
                paymentProvider =>
                {
                    if (paymentProvider == PaymentProvider.Mastercard)
                    {
                        return services.GetRequiredService<MasterCardPaymentGateway>();
                    }
                    else if (paymentProvider == PaymentProvider.Paypal)
                    {
                        return services.GetRequiredService<PaypalPaymentGateway>();
                    }
                    else if (paymentProvider == PaymentProvider.Visa)
                    {
                        return services.GetRequiredService<VisaPaymentGateway>();
                    }
                    else
                    {
                        throw new NotSupportedException($"Not supported payment provider");
                    }
                });

            services.AddScoped<IDataProvider<long, BillingUserDto>, BillingUserDataProvider>();
            services.AddScoped<IDataProvider<IEnumerable<long>, IEnumerable<ProductDto>>, ProductsDataProvider>();

            services.AddScoped<IMapper<(OrderRequestData OrderRequestData, IEnumerable<ProductDto> Products), OrderDto>, DataToOrderDtoMapper>();
            services.AddScoped<IMapper<(OrderDto OrderDto, BillingUserDto BillingUserDto), Receipt>, DataToReceiptMapper>();
            services.AddScoped<IMapper<OrderDto, Order>, OrderDtoToOrderMapper>();
            services.AddScoped<IMapper<OrderDto, Payment>, OrderDtoToPaymentMapper>();

            services.AddScoped<IDataAggregator<OrderRequestData, (IEnumerable<ProductDto> Products, BillingUserDto User)>, OrderDataAggregator>();
            services.AddScoped<IDataDistributor<OrderDto, OrderDistributionResult>, OrderDataDistributor>();
            services.AddScoped<IDataTarget<Order>, OrderDataTarget>();
            services.AddScoped<IRequestPipeline<OrderRequestData, Receipt>, OrderRequestPipeline>();
        }
    }
}
