using System;
using System.Collections.Generic;
using System.Globalization;

namespace Datasets {
  public class Thoracic_SurgeryDataset : Dataset {
    public Thoracic_SurgeryDataset() : base() {
      string csv = Properties.Resources.tsurgery;

      DataSet.AddRange(ParseDataFromString(csv));
      CreateMappedDataset();
    }

    #region implemented abstract members of Dataset

    public override int[] OutputIndicies() {
      return new int[] {
        16 //Risk1Y: 1 year survival period - (T)rue value if died (T,F) 
      };
    }

    public override int[] InputIndicies() {
      return new int[] {
        0, //DGN: Diagnosis - specific combination of ICD-10 codes for primary and secondary as well multiple tumours if any (DGN3,DGN2,DGN4,DGN6,DGN5,DGN8,DGN1) 
        1, //PRE4: Forced vital capacity - FVC (numeric) 
        2, //PRE5: Volume that has been exhaled at the end of the first second of forced expiration - FEV1 (numeric) 
        3, //PRE6: Performance status - Zubrod scale (PRZ2,PRZ1,PRZ0) 
        4, //PRE7: Pain before surgery (T,F) 
        5, //PRE8: Haemoptysis before surgery (T,F) 
        6, //PRE9: Dyspnoea before surgery (T,F) 
        7, //PRE10: Cough before surgery (T,F) 
        8, //PRE11: Weakness before surgery (T,F) 
        9, //PRE14: T in clinical TNM - size of the original tumour, from OC11 (smallest) to OC14 (largest) (OC11,OC14,OC12,OC13) 
        10, //PRE17: Type 2 DM - diabetes mellitus (T,F) 
        11, //PRE19: MI up to 6 months (T,F) 
        12, //PRE25: PAD - peripheral arterial diseases (T,F) 
        13, //PRE30: Smoking (T,F) 
        14, //PRE32: Asthma (T,F) 
        15 //AGE: Age at surgery (numeric) 
      };
    }

    protected override void CreateMappedDataset() {
      throw new NotImplementedException();
    }

    #endregion
  }
}

