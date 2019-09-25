using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using NetBarcode;

namespace DFeBR.EmissorNFe.Danfe.NFe
{
    public class TaxInvoiceHTMLGenerator// : HTMLGenerator<NFeTaxInvoice, NFeParameters>
    {
    //    public override string GeneratorPathType
    //    {
    //        get
    //        {
    //            return "NFe";
    //        }
    //    }

    //    public override bool HasScript
    //    {
    //        get
    //        {
    //            return true;
    //        }
    //    }

    //    public override string HeaderMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        return this.ReadTemplateReplaceValues(PrintingTemplates.Header, new Dictionary<string, string>()
    //  {
    //    {
    //      "#IssuerCompanyName#",
    //      entityGenerator.Issuer.CompanyName
    //    },
    //    {
    //      "#RecipientCompanyName#",
    //      entityGenerator.Recipient.CompanyName ?? entityGenerator.Recipient.RecipientName
    //    },
    //    {
    //      "#RecipientCompanyNameStyle#",
    //      (entityGenerator.Recipient.CompanyName ?? entityGenerator.Recipient.RecipientName).Length >= 40 ? "font-size:0.8em;" : string.Empty
    //    },
    //    {
    //      "#DocumentAmount#",
    //      entityGenerator.Totals.Amount.FormatNumber().FormatNumberExibicaoDANFE()
    //    },
    //    {
    //      "#Number#",
    //      entityGenerator.EmissionData.DocumentNumber.ToString()
    //    },
    //    {
    //      "#Serie#",
    //      entityGenerator.EmissionData.Serie.ToString()
    //    }
    //  });
    //    }

    //    public override string BodyMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        return this.ReadTemplateReplaceValues(PrintingTemplates.Body, new Dictionary<string, string>()
    //  {
    //    {
    //      "#Issuer#",
    //      this.IssuerMounting(entityGenerator)
    //    },
    //    {
    //      "#Recipient#",
    //      this.RecipientMounting(entityGenerator)
    //    },
    //    {
    //      "#Invoice#",
    //      this.InvoiceMounting(entityGenerator)
    //    },
    //    {
    //      "#Totals#",
    //      this.TotalMounting(entityGenerator)
    //    },
    //    {
    //      "#Transport#",
    //      this.TransportMounting(entityGenerator)
    //    },
    //    {
    //      "#Products#",
    //      this.ProductsMounting(entityGenerator)
    //    },
    //    {
    //      "#ISSQN#",
    //      this.ISSQNMounting(entityGenerator)
    //    },
    //    {
    //      "#AdditionalInformation#",
    //      this.AdditionalInformationsMounting(entityGenerator)
    //    }
    //  });
    //    }

    //    public override string FooterMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        string str1 = string.Empty;
    //        string str2 = string.Empty;
    //        if (this._parameterModel.Stats.Equals("Canceled"))
    //            str1 = "NOTA FISCAL CANCELADA";
    //        else if (this._parameterModel.Stats.Equals("Denied"))
    //            str1 = "NOTA FISCAL DENEGADA";
    //        else if (this._parameterModel.Stats.Equals("Refused"))
    //            str1 = "SEM VALOR FISCAL";
    //        else if (this._parameterModel.Stats.Equals("WaitingApproval"))
    //        {
    //            str1 = "PRÉ-VISUALIZAÇÃO";
    //            str2 = "SEM VALOR FISCAL";
    //        }
    //        if (entityGenerator.EmissionData.Environment == 2)
    //        {
    //            str1 = "HOMOLOGAÇÃO";
    //            str2 = "SEM VALOR FISCAL";
    //        }
    //        return this.ReadTemplateReplaceValues(PrintingTemplates.Footer, new Dictionary<string, string>()
    //  {
    //    {
    //      "#WaterMark#",
    //      str1
    //    },
    //    {
    //      "#WithOutValue#",
    //      str2
    //    }
    //  });
    //    }

    //    public override List<ReplaceJsTags> ReplaceJsTags()
    //    {
    //        return new List<ReplaceJsTags>()
    //  {
    //    new ReplaceJsTags()
    //    {
    //      ReplaceTag = "#pageHeigth#",
    //      HtmlValue = "1400",
    //      PdfValue = "1050"
    //    },
    //    new ReplaceJsTags()
    //    {
    //      ReplaceTag = "#waterMarkTop#",
    //      HtmlValue = "70%",
    //      PdfValue = "40%"
    //    },
    //    new ReplaceJsTags()
    //    {
    //      ReplaceTag = "#waterMarkLeft#",
    //      HtmlValue = "35%",
    //      PdfValue = "25%"
    //    }
    //  };
    //    }

    //    private string ProductsMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        StringBuilder stringBuilder = new StringBuilder();
    //        foreach (Product product in entityGenerator.Products)
    //        {
    //            Dictionary<string, string> dictionary = new Dictionary<string, string>();
    //            dictionary.Add("#ProductCode#", product.ProductCode ?? string.Empty);
    //            dictionary.Add("#Description#", (product.Description + " " + (product.AdditionalInformation ?? string.Empty)).Trim());
    //            dictionary.Add("#NCM#", product.NCM ?? string.Empty);
    //            dictionary.Add("#ProductOrigin#", product.ProductOrigin + (product.Taxes?.ICMS?.CSOSN ?? string.Empty));
    //            dictionary.Add("#CFOP#", product.CFOP ?? string.Empty);
    //            dictionary.Add("#Unit#", product.CommercialUnitOfMeasurement == null ? string.Empty : product.CommercialUnitOfMeasurement.ToUpper());
    //            dictionary.Add("#Quantity#", product.CommercialQuantity.FormatRateNumber().FormatNumberQuantityDANFE());
    //            dictionary.Add("#UnityValue#", product.UnityValue.FormatNumber().FormatNumberExibicaoDANFE());
    //            dictionary.Add("#Amount#", product.Amount.FormatNumber().FormatNumberExibicaoDANFE());
    //            string key1 = "#CalculationBasis#";
    //            NFeGenerator.Entities.TaxInvoice.Taxes.Taxes taxes1 = product.Taxes;
    //            string str1 = taxes1 != null ? taxes1.ICMS.CalculationBasis.FormatNumber().FormatNumberExibicaoDANFE() : (string)null;
    //            dictionary.Add(key1, str1);
    //            string key2 = "#ICMSValue#";
    //            NFeGenerator.Entities.TaxInvoice.Taxes.Taxes taxes2 = product.Taxes;
    //            string str2 = taxes2 != null ? taxes2.ICMS.Value.FormatNumber().FormatNumberExibicaoDANFE() : (string)null;
    //            dictionary.Add(key2, str2);
    //            string key3 = "#ICMSRate#";
    //            NFeGenerator.Entities.TaxInvoice.Taxes.Taxes taxes3 = product.Taxes;
    //            string str3 = taxes3 != null ? taxes3.ICMS.Rate.FormatNumber().FormatNumberExibicaoDANFE() : (string)null;
    //            dictionary.Add(key3, str3);
    //            string key4 = "#IPIValue#";
    //            NFeGenerator.Entities.TaxInvoice.Taxes.Taxes taxes4 = product.Taxes;
    //            string str4 = taxes4 != null ? taxes4.IPI.TotalValue.FormatNumber().FormatNumberExibicaoDANFE() : (string)null;
    //            dictionary.Add(key4, str4);
    //            string key5 = "#IPIRatePercentual#";
    //            NFeGenerator.Entities.TaxInvoice.Taxes.Taxes taxes5 = product.Taxes;
    //            string str5 = taxes5 != null ? taxes5.IPI.PercentualRate.FormatNumber().FormatNumberExibicaoDANFE() : (string)null;
    //            dictionary.Add(key5, str5);
    //            Dictionary<string, string> dictionaryReplace = dictionary;
    //            stringBuilder.Append(this.ReadTemplateReplaceValues(PrintingTemplates.Products, dictionaryReplace));
    //        }
    //        return stringBuilder.ToString();
    //    }

    //    private string AdditionalInformationsMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        string str1 = this.ReplaceAdditionalInformation(entityGenerator.AdditionalInformation.FiscoInformation ?? string.Empty);
    //        string str2 = this.ReplaceAdditionalInformation(entityGenerator.AdditionalInformation.Information ?? string.Empty);
    //        if (!string.IsNullOrEmpty(entityGenerator.AdditionalInformation.ObligatoryInformation))
    //            str2 = str2 + "<br>" + this.ReplaceAdditionalInformation(entityGenerator.AdditionalInformation.ObligatoryInformation);
    //        return this.ReadTemplateReplaceValues(PrintingTemplates.AdditionalInformation, new Dictionary<string, string>()
    //  {
    //    {
    //      "#Information#",
    //      str2
    //    },
    //    {
    //      "#FiscoInformation#",
    //      str1
    //    }
    //  });
    //    }

    //    private string ISSQNMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        if (entityGenerator.EmissionData.IsNFeConjugated)
    //            return string.Empty;
    //        Dictionary<string, string> dictionaryReplace = new Dictionary<string, string>();
    //        string key = "#IM#";
    //        string im = entityGenerator.Recipient.IM;
    //        string str = (im != null ? im.FormatSemCaracteres().Trim().ToUpper() : (string)null) ?? string.Empty;
    //        dictionaryReplace.Add(key, str);
    //        dictionaryReplace.Add("#ServicesAmount#", entityGenerator.Totals.ISSAmount.FormatNumber().FormatNumberExibicaoDANFE());
    //        dictionaryReplace.Add("#ISSCalculationBasisAmount#", entityGenerator.Totals.ISSAmount.FormatNumber().FormatNumberExibicaoDANFE());
    //        dictionaryReplace.Add("#ISSAmount#", entityGenerator.Totals.ISSAmount.FormatNumber().FormatNumberExibicaoDANFE());
    //        return this.ReadTemplateReplaceValues(PrintingTemplates.ISSQN, dictionaryReplace);
    //    }

    //    private string TransportMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        Dictionary<string, string> dictionaryReplace = new Dictionary<string, string>();
    //        dictionaryReplace.Add("#CpfCnpj#", !string.IsNullOrEmpty(entityGenerator.ShippingCompany.CNPJ) ? entityGenerator.ShippingCompany.CNPJ.FormatCNPJ_CPF() : (!string.IsNullOrEmpty(entityGenerator.ShippingCompany.CPF) ? entityGenerator.ShippingCompany.CPF.FormatCNPJ_CPF() : string.Empty));
    //        dictionaryReplace.Add("#VehicleState#", entityGenerator.ShippingCompany.ShippingCompanyVehicle.StateCode ?? string.Empty);
    //        dictionaryReplace.Add("#VehiclePlate#", entityGenerator.ShippingCompany.ShippingCompanyVehicle.Plate ?? string.Empty);
    //        dictionaryReplace.Add("#VehicleRNTC#", entityGenerator.ShippingCompany.ShippingCompanyVehicle.RNTC ?? string.Empty);
    //        dictionaryReplace.Add("#FreightMode#", entityGenerator.ShippingCompany.FreightMode.GetAttribute<DescriptionAttribute>((System.Type)null).Description);
    //        dictionaryReplace.Add("#CompanyName#", entityGenerator.ShippingCompany.CompanyName?.ToUpper() ?? string.Empty);
    //        string key1 = "#CompanyNameStyle#";
    //        string companyName = entityGenerator.ShippingCompany.CompanyName;
    //        string str1 = (companyName != null ? (companyName.Length >= 60 ? 1 : 0) : 0) != 0 ? "font-size:0.8em;" : string.Empty;
    //        dictionaryReplace.Add(key1, str1);
    //        dictionaryReplace.Add("#IE#", entityGenerator.ShippingCompany.IE ?? string.Empty);
    //        dictionaryReplace.Add("#StateCode#", entityGenerator.ShippingCompany.StateCode ?? string.Empty);
    //        dictionaryReplace.Add("#City#", entityGenerator.ShippingCompany.City ?? string.Empty);
    //        string key2 = "#CityStyle#";
    //        string city = entityGenerator.ShippingCompany.City;
    //        string str2 = (city != null ? (city.Length >= 10 ? 1 : 0) : 0) != 0 ? "font-size:0.8em;" : string.Empty;
    //        dictionaryReplace.Add(key2, str2);
    //        dictionaryReplace.Add("#Street#", entityGenerator.ShippingCompany.Street?.ToUpper() ?? string.Empty);
    //        string key3 = "#StreetStyle#";
    //        string street = entityGenerator.ShippingCompany.Street;
    //        string str3 = (street != null ? (street.Length >= 45 ? 1 : 0) : 0) != 0 ? "font-size:0.7em;" : string.Empty;
    //        dictionaryReplace.Add(key3, str3);
    //        dictionaryReplace.Add("#Volumes#", this.TransportVolumesMounting(entityGenerator));
    //        dictionaryReplace.Add("#Trailers#", this.TransportTrailerMounting(entityGenerator));
    //        return this.ReadTemplateReplaceValues(PrintingTemplates.Transport, dictionaryReplace);
    //    }

    //    private string TransportVolumesMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        if (entityGenerator.ShippingCompany.ShippingCompanyVolumes == null || entityGenerator.ShippingCompany.ShippingCompanyVolumes.Count<ShippingCompanyVolumes>() == 0)
    //            return string.Empty;
    //        bool flag = entityGenerator.ShippingCompany.ShippingCompanyVolumes.Count > 1;
    //        Dictionary<string, string> dictionary1 = new Dictionary<string, string>();
    //        Dictionary<string, string> dictionaryReplace;
    //        if (flag)
    //        {
    //            dictionaryReplace = new Dictionary<string, string>()
    //    {
    //      {
    //        "#VolumesItems#",
    //        this.TransportVolumesList(entityGenerator.ShippingCompany.ShippingCompanyVolumes)
    //      }
    //    };
    //        }
    //        else
    //        {
    //            ShippingCompanyVolumes shippingCompanyVolumes = entityGenerator.ShippingCompany.ShippingCompanyVolumes.FirstOrDefault<ShippingCompanyVolumes>();
    //            Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
    //            dictionary2.Add("#Quantity#", shippingCompanyVolumes.Quantity);
    //            dictionary2.Add("#Specie#", shippingCompanyVolumes.Specie);
    //            dictionary2.Add("#Brand#", shippingCompanyVolumes.Brand);
    //            string key1 = "#GrossWeight#";
    //            string grossWeight = shippingCompanyVolumes.GrossWeight;
    //            string str1 = (grossWeight != null ? grossWeight.FormatNumberPesoDanfe() : (string)null) ?? string.Empty;
    //            dictionary2.Add(key1, str1);
    //            string key2 = "#NetWeight#";
    //            string netWeight = shippingCompanyVolumes.NetWeight;
    //            string str2 = (netWeight != null ? netWeight.FormatNumberPesoDanfe() : (string)null) ?? string.Empty;
    //            dictionary2.Add(key2, str2);
    //            dictionaryReplace = dictionary2;
    //        }
    //        return this.ReadTemplateReplaceValues(flag ? PrintingTemplates.VolumeList : PrintingTemplates.Volume, dictionaryReplace);
    //    }

    //    private string TransportVolumesList(List<ShippingCompanyVolumes> volumes)
    //    {
    //        StringBuilder stringBuilder = new StringBuilder();
    //        foreach (ShippingCompanyVolumes volume in volumes)
    //        {
    //            Dictionary<string, string> dictionary = new Dictionary<string, string>();
    //            dictionary.Add("#Quantity#", volume.Quantity);
    //            dictionary.Add("#Specie#", volume.Specie);
    //            dictionary.Add("#Brand#", volume.Brand);
    //            string key1 = "#GrossWeight#";
    //            string grossWeight = volume.GrossWeight;
    //            string str1 = (grossWeight != null ? grossWeight.FormatNumberPesoDanfe() : (string)null) ?? string.Empty;
    //            dictionary.Add(key1, str1);
    //            string key2 = "#NetWeight#";
    //            string netWeight = volume.NetWeight;
    //            string str2 = (netWeight != null ? netWeight.FormatNumberPesoDanfe() : (string)null) ?? string.Empty;
    //            dictionary.Add(key2, str2);
    //            Dictionary<string, string> dictionaryReplace = dictionary;
    //            stringBuilder.Append(this.ReadTemplateReplaceValues(PrintingTemplates.VolumeListItem, dictionaryReplace));
    //        }
    //        return stringBuilder.ToString();
    //    }

    //    private string TransportTrailerMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        if (entityGenerator.ShippingCompany.ShippingCompanyVehicle.Trailers == null || entityGenerator.ShippingCompany.ShippingCompanyVehicle.Trailers.Count<Trailer>() == 0)
    //            return string.Empty;
    //        return this.ReadTemplateReplaceValues(PrintingTemplates.Trailer, new Dictionary<string, string>()
    //  {
    //    {
    //      "#TrailerItems#",
    //      this.TransportTrailerItemsMounting(entityGenerator.ShippingCompany.ShippingCompanyVehicle.Trailers)
    //    }
    //  });
    //    }

    //    private string TransportTrailerItemsMounting(List<Trailer> trailers)
    //    {
    //        StringBuilder stringBuilder = new StringBuilder();
    //        foreach (Trailer trailer in trailers)
    //        {
    //            Dictionary<string, string> dictionaryReplace = new Dictionary<string, string>()
    //    {
    //      {
    //        "#Plate#",
    //        trailer.Plate
    //      },
    //      {
    //        "#RNTC#",
    //        trailer.RNTC ?? string.Empty
    //      },
    //      {
    //        "#StateCode#",
    //        trailer.StateCode
    //      }
    //    };
    //            stringBuilder.Append(this.ReadTemplateReplaceValues(PrintingTemplates.TrailerItem, dictionaryReplace));
    //        }
    //        return stringBuilder.ToString();
    //    }

    //    private string TotalMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        return this.ReadTemplateReplaceValues(PrintingTemplates.Total, new Dictionary<string, string>()
    //  {
    //    {
    //      "#ICMSCalculationBasisAmount#",
    //      entityGenerator.Totals.ICMSCalculationBasisAmount.FormatNumber().FormatNumberExibicaoDANFE()
    //    },
    //    {
    //      "#ICMSAmount#",
    //      entityGenerator.Totals.ICMSAmount.FormatNumber().FormatNumberExibicaoDANFE()
    //    },
    //    {
    //      "#ICMSSTCalculationBasisAmount#",
    //      entityGenerator.Totals.ICMSSTCalculationBasisAmount.FormatNumber().FormatNumberExibicaoDANFE()
    //    },
    //    {
    //      "#ICMSSTAmount#",
    //      entityGenerator.Totals.ICMSSTAmount.FormatNumber().FormatNumberExibicaoDANFE()
    //    },
    //    {
    //      "#ProductsAmount#",
    //      entityGenerator.Totals.ProductsAmount.FormatNumber().FormatNumberExibicaoDANFE()
    //    },
    //    {
    //      "#FreightAmount#",
    //      entityGenerator.Totals.FreightAmount.FormatNumber().FormatNumberExibicaoDANFE()
    //    },
    //    {
    //      "#InsuranceAmount#",
    //      entityGenerator.Totals.InsuranceAmount.FormatNumber().FormatNumberExibicaoDANFE()
    //    },
    //    {
    //      "#DiscountAmount#",
    //      entityGenerator.Totals.DiscountAmount.FormatNumber().FormatNumberExibicaoDANFE()
    //    },
    //    {
    //      "#OtherExpensesAmount#",
    //      entityGenerator.Totals.OtherExpensesAmount.FormatNumber().FormatNumberExibicaoDANFE()
    //    },
    //    {
    //      "#IPIAmount#",
    //      entityGenerator.Totals.IPIAmount.FormatNumber().FormatNumberExibicaoDANFE()
    //    },
    //    {
    //      "#DocumentAmount#",
    //      entityGenerator.Totals.Amount.FormatNumber().FormatNumberExibicaoDANFE()
    //    }
    //  });
    //    }

    //    private string InvoiceMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        return this.ReadTemplateReplaceValues(PrintingTemplates.Invoice, new Dictionary<string, string>()
    //  {
    //    {
    //      "#InvoiceItems#",
    //      this.InvoiceItemsMounting(entityGenerator)
    //    }
    //  });
    //    }

    //    private string InvoiceItemsMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        StringBuilder stringBuilder = new StringBuilder();
    //        if (entityGenerator.Invoice != null)
    //        {
    //            List<Bill> bills = entityGenerator.Invoice.Bills;
    //            // ISSUE: explicit non-virtual call
    //            if ((bills != null ? ((bills.Count) > 0 ? 1 : 0) : 0) != 0)
    //            {
    //                string str1 = !string.IsNullOrEmpty(entityGenerator.Invoice.Number) ? "Fat nº : " + entityGenerator.Invoice.Number : string.Empty;
    //                string str2 = entityGenerator.Invoice.OriginalValue > Decimal.Zero ? "/ Valor Orig. : " + entityGenerator.Invoice.OriginalValue.FormatNumber().FormatNumberExibicaoDANFE() : string.Empty;
    //                string str3 = entityGenerator.Invoice.DiscountValue > Decimal.Zero ? "/ Valor Desc. : " + entityGenerator.Invoice.DiscountValue.FormatNumber().FormatNumberExibicaoDANFE() : string.Empty;
    //                string str4 = entityGenerator.Invoice.NetValue > Decimal.Zero ? "/ Valor Liq. : " + entityGenerator.Invoice.NetValue.FormatNumber().FormatNumberExibicaoDANFE() : string.Empty;
    //                foreach (Bill bill in entityGenerator.Invoice.Bills)
    //                {
    //                    string str5 = !string.IsNullOrEmpty(bill.Number) ? "<b>Dup. nº</b>: " + bill.Number + "&nbsp" : string.Empty;
    //                    string str6 = bill.ExpirationDate != DateTime.MinValue ? ",<b>Venc.</b>: " + bill.ExpirationDate.ToString("dd/MM/yyyy") + "&nbsp" : string.Empty;
    //                    string str7 = bill.Value > Decimal.Zero ? ", <b>Valor</b>:" + bill.Value.FormatNumber().FormatNumberExibicaoDANFE() + "&nbsp" : string.Empty;
    //                    Dictionary<string, string> dictionaryReplace = new Dictionary<string, string>()
    //        {
    //          {
    //            "#BillItem#",
    //            str1 + " " + str2 + " " + str3 + " " + str4 + " " + str5 + str6 + str7
    //          }
    //        };
    //                    stringBuilder.Append(this.ReadTemplateReplaceValues(PrintingTemplates.InvoiceItem, dictionaryReplace));
    //                }
    //            }
    //        }
    //        return stringBuilder.ToString();
    //    }

    //    private string RecipientMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        Dictionary<string, string> dictionaryReplace = new Dictionary<string, string>();
    //        string key1 = "#EmissionDate#";
    //        DateTime dateTime;
    //        string empty1;
    //        if (!(entityGenerator.EmissionData.EmissionDate == DateTime.MinValue))
    //        {
    //            dateTime = entityGenerator.EmissionData.EmissionDate;
    //            empty1 = dateTime.ToString("dd/MM/yyyy");
    //        }
    //        else
    //            empty1 = string.Empty;
    //        dictionaryReplace.Add(key1, empty1);
    //        dictionaryReplace.Add("#CompanyName#", entityGenerator.Recipient.RecipientName.ToUpper());
    //        dictionaryReplace.Add("#CpfCnpj#", !string.IsNullOrEmpty(entityGenerator.Recipient.CNPJ) ? entityGenerator.Recipient.CNPJ.RemoveAllTags() : (!string.IsNullOrEmpty(entityGenerator.Recipient.CPF) ? entityGenerator.Recipient.CPF.RemoveAllTags() : string.Empty));
    //        string key2 = "#InOutProductData#";
    //        string empty2;
    //        if (!(entityGenerator.EmissionData.InOutProductData == DateTime.MinValue))
    //        {
    //            dateTime = entityGenerator.EmissionData.InOutProductData;
    //            empty2 = dateTime.ToString("dd/MM/yyyy");
    //        }
    //        else
    //            empty2 = string.Empty;
    //        dictionaryReplace.Add(key2, empty2);
    //        dictionaryReplace.Add("#ZipCode#", entityGenerator.Recipient.RecipientAddress.ZipCode ?? string.Empty);
    //        dictionaryReplace.Add("#Neighborhood#", entityGenerator.Recipient.RecipientAddress.Neighborhood.ToUpper());
    //        dictionaryReplace.Add("#Address#", this.GetAddress(entityGenerator.Recipient.RecipientAddress, false).ToUpper());
    //        string key3 = "#InOutProductDataTime#";
    //        string empty3;
    //        if (!(entityGenerator.EmissionData.InOutProductData == DateTime.MinValue))
    //        {
    //            dateTime = entityGenerator.EmissionData.InOutProductData;
    //            empty3 = dateTime.ToString("HH:mm:ss");
    //        }
    //        else
    //            empty3 = string.Empty;
    //        dictionaryReplace.Add(key3, empty3);
    //        dictionaryReplace.Add("#IE#", entityGenerator.Recipient.IEExempt ? "ISENTO" : entityGenerator.Recipient.IE ?? string.Empty);
    //        dictionaryReplace.Add("#StateCode#", entityGenerator.Recipient.RecipientAddress.StateCode.ToUpper());
    //        dictionaryReplace.Add("#Phone#", entityGenerator.Recipient.RecipientAddress.Phone ?? string.Empty);
    //        dictionaryReplace.Add("#City#", entityGenerator.Recipient.RecipientAddress.City.ToUpper());
    //        return this.ReadTemplateReplaceValues(PrintingTemplates.Recipient, dictionaryReplace);
    //    }

    //    private string IssuerMounting(NFeTaxInvoice entityGenerator)
    //    {
    //        Dictionary<string, string> dictionaryReplace = new Dictionary<string, string>();
    //        dictionaryReplace.Add("#Logo#", !string.IsNullOrEmpty(this._parameterModel.Logo) ? this._parameterModel.Logo : "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wAARCABeAGQDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD3qONPLX5V6DsPSneVH/cX8qI/9Wv0FPoAZ5Uf9xfyo8qP+4v5U+igBnlR/wBxfyo8qP8AuL+VPooAZ5Uf9xfyo8qP+4v5U+igBnlR/wBxfyo8qP8AuL+VPooAZ5Uf9xfyo8qP+4v5U+igCvJGm77q9PQUU6X734UUAPj/ANWv0FPpkf8Aq1+gp9ABRRSE4oAWkLqvVgPqapyXDyvshz9aVbIHl3JPfFAFkTRk4Dr+dOz6VW+xR/3m/OmGKW3O6NiyjqKALtFQwTiYejdxU1ABRRRQBDL978KKJfvfhRQA+P8A1a/QU+mR/wCrX6Cn0AFVLyQ/LEvVutW6pfev+e3+FADZIRAFKyASemetSi9jWEu+cr1AGaxtXP8AxMWGTgKMe1WLKSS6Rsgl0HJ/vUAaLX0ccipKrRbuhbGKcb6383y/NXJGc54/OsuXT454maJ2EqjOxjkfhWRjjp+FAHSzr5UizRngntVxGDoGHQis6y+fRVLckA4/Amrdmf8ARwPQ4oAsUUUUAQy/e/CiiX734UUAPj/1a/QU+mR/6tfoKfQAVSf93fAnof8A9VXar3UPmJuX7y9PegDD1f8A5CD/AEH8qdpV4lrIyy8I/wDF6GtVBBdKFnjVnX1HWpP7Ps/+feP8qAK801u0imGaMyMeitnNZV1aBcyxD5OrL/d/+tW79gtAc+RGPwptzAMGRMAjqPWgCtZts0WMHqcj/wAeNXbRStuue+TVUbrlkQKFRRyB2rQAAUAdBQAtFFFAEMv3vwool+9+FFAD4/8AVr9BT6ZH/q1+gp9ABRRRQBWmtVc7lIVv51H5l1Fwy7h64zV2igCl9pmPAi/Q0nlTzHMp2r6f/Wq9RQAyONY12qMU+iigAooooAhl+9+FFEv3vwooAfH/AKtfoKfUMcgEa9eg7U7zV9DQBJRUfmr6GjzV9DQBJRUfmr6GjzV9DQBJRUfmr6GjzV9DQBJRUfmr6GjzV9DQBJRUfmr6GjzV9DQA2X734UU2SQbvw9KKAP/Z");
    //        dictionaryReplace.Add("#BarCode#", string.IsNullOrEmpty(entityGenerator.NFeID) ? string.Empty : this.GenerationQRCode(entityGenerator.NFeID));
    //        dictionaryReplace.Add("#CompanyName#", entityGenerator.Issuer.CompanyName.ToUpper());
    //        dictionaryReplace.Add("#VerificationCode#", string.IsNullOrEmpty(entityGenerator.NFeID) ? string.Empty : entityGenerator.NFeID.FormatSpaced(4));
    //        dictionaryReplace.Add("#OperationType#", entityGenerator.EmissionData.OperationType);
    //        string key1 = "#Number#";
    //        int num = entityGenerator.EmissionData.DocumentNumber;
    //        string str1 = num.ToString();
    //        dictionaryReplace.Add(key1, str1);
    //        string key2 = "#Serie#";
    //        num = entityGenerator.EmissionData.Serie;
    //        string str2 = num.ToString();
    //        dictionaryReplace.Add(key2, str2);
    //        dictionaryReplace.Add("#IEST#", entityGenerator.Issuer.IEST ?? string.Empty);
    //        dictionaryReplace.Add("#IE#", entityGenerator.Issuer.IE);
    //        dictionaryReplace.Add("#CpfCnpj#", !string.IsNullOrEmpty(entityGenerator.Issuer.CNPJ) ? entityGenerator.Issuer.CNPJ.FormatCNPJ_CPF() : (!string.IsNullOrEmpty(entityGenerator.Issuer.CPF) ? entityGenerator.Issuer.CPF.FormatCNPJ_CPF() : string.Empty));
    //        dictionaryReplace.Add("#NatureOperation#", string.IsNullOrEmpty(entityGenerator.EmissionData.NatureOperation) ? string.Empty : (entityGenerator.EmissionData.NatureOperation.Length > 55 ? entityGenerator.EmissionData.NatureOperation.ToUpper().Substring(0, 55) : entityGenerator.EmissionData.NatureOperation.ToUpper()));
    //        dictionaryReplace.Add("#Protocol#", this._parameterModel.Protocol ?? " - ");
    //        dictionaryReplace.Add("#DateStats#", entityGenerator.EmissionData.EmissionDate == DateTime.MinValue ? string.Empty : entityGenerator.EmissionData.EmissionDate.ToString("dd/MM/yyyy"));
    //        dictionaryReplace.Add("#DateStatsTime#", entityGenerator.EmissionData.EmissionDate == DateTime.MinValue ? string.Empty : entityGenerator.EmissionData.EmissionDate.ToString("HH:mm:ss"));
    //        dictionaryReplace.Add("#Address#", this.GetAddress(entityGenerator.Issuer.Address, true));
    //        return this.ReadTemplateReplaceValues(PrintingTemplates.Issuer, dictionaryReplace);
    //    }

    //    private string GetAddress(Address address, bool complet)
    //    {
    //        string str = address.Street;
    //        if (!string.IsNullOrEmpty(address.StreetNumber))
    //            str = str + ", " + address.StreetNumber;
    //        if (!string.IsNullOrEmpty(address.Complement))
    //            str = str + " - " + address.Complement;
    //        if (complet)
    //        {
    //            str = str + " - " + address.Neighborhood + " - " + address.City + ", " + address.StateCode + " - CEP : " + address.ZipCode;
    //            if (!string.IsNullOrEmpty(address.Phone))
    //                str = str + " - Fone : " + address.Phone;
    //        }
    //        return str;
    //    }

    //    private string ReplaceAdditionalInformation(string information)
    //    {
    //        information = information.Replace("||", "|").Replace("||", "|").Replace("||", "|").Replace("||", "|");
    //        information = information.Replace("|", "<br/>").Replace("&#13;", "<br/>");
    //        return information;
    //    }

    //    private string GenerationQRCode(string nFeId)
    //    {
    //        return "data:image/png;base64, " + new Barcode(nFeId, NetBarcode.Type.Code128).GetBase64Image();
    //    }
    }
}
