﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PX.Crop.Domain.Messages.Crop.DomainValidation {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class DomainValidationMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DomainValidationMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PX.Crop.Domain.Messages.Crop.DomainValidation.DomainValidationMessages", typeof(DomainValidationMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não é permitido cadastro de marca com o mesmo nome.
        /// </summary>
        public static string BrandCropCreateBrandWithSameName {
            get {
                return ResourceManager.GetString("BrandCropCreateBrandWithSameName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Esta safra é valorada, é obrigatório preencher o campo preço.
        /// </summary>
        public static string BrandCropCreateCropPlanningValuedPriceRequired {
            get {
                return ResourceManager.GetString("BrandCropCreateCropPlanningValuedPriceRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Só é permitida exclusão de marca para tipo CP.
        /// </summary>
        public static string BrandCropIsNotCPType {
            get {
                return ResourceManager.GetString("BrandCropIsNotCPType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erro ao editar esta classificação {0} para {1}. O sistema identificou que existem parceiros com esta classificação.
        /// </summary>
        public static string ClassificationCropCodeAlreadyInUse {
            get {
                return ResourceManager.GetString("ClassificationCropCodeAlreadyInUse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não é permitido cadastro de classificação com o mesmo código..
        /// </summary>
        public static string ClassificationCropDeleteClassificationWithSameCode {
            get {
                return ResourceManager.GetString("ClassificationCropDeleteClassificationWithSameCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Classificação: {0}, não é permitido colocar valor de margem de planejamento para safra que não é valorada.
        /// </summary>
        public static string ClassificationCropNotValuedCrop {
            get {
                return ResourceManager.GetString("ClassificationCropNotValuedCrop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Classificação: {0}, código de classificação já cadastrado.
        /// </summary>
        public static string ClassificationCropSameCode {
            get {
                return ResourceManager.GetString("ClassificationCropSameCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Classificação: {0}, é obrigatório colocar valor de margem de planejamento para safra valorada.
        /// </summary>
        public static string ClassificationCropValuedCrop {
            get {
                return ResourceManager.GetString("ClassificationCropValuedCrop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Classificação não existente para esta safra.
        /// </summary>
        public static string ClassificationNoExistForCrop {
            get {
                return ResourceManager.GetString("ClassificationNoExistForCrop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O status da safra não permite a exclusão de marca elegível.
        /// </summary>
        public static string ClosedOrDeletedBrandCropStatus {
            get {
                return ResourceManager.GetString("ClosedOrDeletedBrandCropStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O status da safra não permite a exclusão desse parceiro..
        /// </summary>
        public static string ClosedOrDeletedPartnerCropStatus {
            get {
                return ResourceManager.GetString("ClosedOrDeletedPartnerCropStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Já existe uma safra neste mesmo período..
        /// </summary>
        public static string CropInSamePeriod {
            get {
                return ResourceManager.GetString("CropInSamePeriod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O status da Safra não permite a inclusão de marca elegível.
        /// </summary>
        public static string CropInStatusIneligible {
            get {
                return ResourceManager.GetString("CropInStatusIneligible", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O status da safra não permite a exclusão de classificação.
        /// </summary>
        public static string CropStatusNotAllowToDeleteClassification {
            get {
                return ResourceManager.GetString("CropStatusNotAllowToDeleteClassification", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Esta classificação não pode ser excluída pois está sendo utilizada no cadastro de documento..
        /// </summary>
        public static string DeleteClassificationAlreadyInDocument {
            get {
                return ResourceManager.GetString("DeleteClassificationAlreadyInDocument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erro ao excluir esta classificação. O sistema identificou que existem parceiros com esta classificação..
        /// </summary>
        public static string DeleteClassificationCropAlreadyInUse {
            get {
                return ResourceManager.GetString("DeleteClassificationCropAlreadyInUse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Classificação não existente para essa safra..
        /// </summary>
        public static string DeleteClassificationCropNotFound {
            get {
                return ResourceManager.GetString("DeleteClassificationCropNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A classificação que você está tentando remover não foi encontrada..
        /// </summary>
        public static string DeleteClassificationNotFound {
            get {
                return ResourceManager.GetString("DeleteClassificationNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A safra não pode ser removida, pois já está fechada..
        /// </summary>
        public static string DeleteClosedCrop {
            get {
                return ResourceManager.GetString("DeleteClosedCrop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A safra que você está tentando remover não foi encontrada..
        /// </summary>
        public static string DeleteCropNotFound {
            get {
                return ResourceManager.GetString("DeleteCropNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Este documento não pode ser excluído pois já foi aceito pelo parceiro..
        /// </summary>
        public static string DocumentCropDelete {
            get {
                return ResourceManager.GetString("DocumentCropDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Já existe nesta safra um documento com o mesmo nome..
        /// </summary>
        public static string DocumentCropDescriptionDuplicate {
            get {
                return ResourceManager.GetString("DocumentCropDescriptionDuplicate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erro ao incluir documento. Documento já cadastrado com as mesmas configurações de Tipo parceiro, Tipo e classificações.
        /// </summary>
        public static string DocumentCropDuplicate {
            get {
                return ResourceManager.GetString("DocumentCropDuplicate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não é possivel cadastrar mais de um documento para tipo lista de preços para essa safra.
        /// </summary>
        public static string DocumentCropPriceListDuplicate {
            get {
                return ResourceManager.GetString("DocumentCropPriceListDuplicate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erro ao excluir esta classificação. O sistema identificou que existem parceiros com esta classificação..
        /// </summary>
        public static string ErrorDeleteClassificationIdentifyPartnerThisClassification {
            get {
                return ResourceManager.GetString("ErrorDeleteClassificationIdentifyPartnerThisClassification", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A importação contém marcas duplicadas.
        /// </summary>
        public static string ImportBrandBrandDuplicated {
            get {
                return ResourceManager.GetString("ImportBrandBrandDuplicated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo marca é obrigatório.
        /// </summary>
        public static string ImportBrandCropBrandRequired {
            get {
                return ResourceManager.GetString("ImportBrandCropBrandRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Só é permitida importação de marcas para safra em rascunho.
        /// </summary>
        public static string ImportBrandCropIsNotInDraft {
            get {
                return ResourceManager.GetString("ImportBrandCropIsNotInDraft", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to API indisponível no momento, por gentileza tentar novamente em alguns minutos.
        /// </summary>
        public static string ImportBrandCropUnavailableApiBrands {
            get {
                return ResourceManager.GetString("ImportBrandCropUnavailableApiBrands", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Lista de parceiros para exclusão apresenta inconsistências.
        /// </summary>
        public static string IncorrectPartnerListToDelete {
            get {
                return ResourceManager.GetString("IncorrectPartnerListToDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Só é possivel remover safras que ainda estão no modo rascunho..
        /// </summary>
        public static string IsNotInDraft {
            get {
                return ResourceManager.GetString("IsNotInDraft", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Marca não existente para esta safra.
        /// </summary>
        public static string NoExistBrandCrop {
            get {
                return ResourceManager.GetString("NoExistBrandCrop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Safra não existente.
        /// </summary>
        public static string NoExistCrop {
            get {
                return ResourceManager.GetString("NoExistCrop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parceiro não existente para esta safra.
        /// </summary>
        public static string NoExistPartnerCrop {
            get {
                return ResourceManager.GetString("NoExistPartnerCrop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não foi possível importar a planilha. As seguintes marcas não foram encontradas na API..
        /// </summary>
        public static string NonExistentBrandsInBayerAPI {
            get {
                return ResourceManager.GetString("NonExistentBrandsInBayerAPI", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O status da safra não permite a inclusão de classificação.
        /// </summary>
        public static string SaveClassificationCropIsNotValid {
            get {
                return ResourceManager.GetString("SaveClassificationCropIsNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não é permitido iniciar o processamento do early payment. Motivo: {0}.
        /// </summary>
        public static string StartEarlyPaymentProcessNotAllowed {
            get {
                return ResourceManager.GetString("StartEarlyPaymentProcessNotAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Marca não existente para esta Safra.
        /// </summary>
        public static string UpdateBrandCropBrandNotExistsInCrop {
            get {
                return ResourceManager.GetString("UpdateBrandCropBrandNotExistsInCrop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Só é permitida alteração para tipo CP.
        /// </summary>
        public static string UpdateBrandCropBrandTypeNotAllowed {
            get {
                return ResourceManager.GetString("UpdateBrandCropBrandTypeNotAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não é permitida alteração para safra que não é valorada.
        /// </summary>
        public static string UpdateBrandCropCropNotGoalPlanningValued {
            get {
                return ResourceManager.GetString("UpdateBrandCropCropNotGoalPlanningValued", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O status da Safra não permite a alteração de marca elegível.
        /// </summary>
        public static string UpdateBrandCropCropWithNotAllowedStatus {
            get {
                return ResourceManager.GetString("UpdateBrandCropCropWithNotAllowedStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não é permitida alteração no campo Valorar Plano de Metas para Safra Ativa.
        /// </summary>
        public static string UpdateCropGoalPlanningValued {
            get {
                return ResourceManager.GetString("UpdateCropGoalPlanningValued", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não é permitida alteração em Safra Fechada ou Excluída.
        /// </summary>
        public static string UpdateCropInvalidStatus {
            get {
                return ResourceManager.GetString("UpdateCropInvalidStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Safra não existente.
        /// </summary>
        public static string UpdateCropNotFound {
            get {
                return ResourceManager.GetString("UpdateCropNotFound", resourceCulture);
            }
        }
    }
}
