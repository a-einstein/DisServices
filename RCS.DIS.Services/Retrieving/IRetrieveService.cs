﻿using RCS.DIS.Services.DTOs;
using System.ServiceModel;

namespace RCS.DIS.Services.Retrieving
{
    // TODO make this asynchronous.
    // TODO Search on AND clauses.
    // TODO Use omschrijvingen of foreign records instead of codes. Disadvantage is the readability because of the lengths.

    [ServiceContract]
    public interface IRetrieveService
    {
        #region Versies
        [OperationContract]
        string[] Versies();
        #endregion

        #region Diagnoses
        [OperationContract]
        int DiagnoseOmschrijvingContainsNumber(string searchString);

        [OperationContract]
        Diagnose[] DiagnoseOmschrijvingContainsEntities(string searchString);
        #endregion

        #region Specialismes
        [OperationContract]
        int SpecialismeOmschrijvingContainsNumber(string searchString);

        [OperationContract]
        Specialisme[] SpecialismeOmschrijvingContainsEntities(string searchString);
        #endregion

        #region Zorgactiviteiten
        [OperationContract]
        int ZorgactiviteitOmschrijvingContainsNumber(string searchString);

        [OperationContract]
        Zorgactiviteit[] ZorgactiviteitOmschrijvingContainsEntities(string searchString);
        #endregion

        #region Zorgproducten
        [OperationContract]
        int ZorgproductOmschrijvingContainsNumber(string searchString);

        [OperationContract]
        Zorgproduct[] ZorgproductOmschrijvingContainsEntities(string searchString);
        #endregion
    }
}
