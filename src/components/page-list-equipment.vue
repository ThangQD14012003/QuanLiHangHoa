<template>
  <!-- <div>
    <h4>pages/query/page-list-equipment.vue</h4>
  </div> -->

  <div class="bg-white create-news-wrap">
    <div class="flex flex-col md:flex-row">
      <ul class="pop-lst-info w-full">
        
        <li class="flex flex-col">
          <div class="form-floating mb-3">
            <label>file Input Excel có danh sách các Model tên thiết bị</label>
            <input
              type="file"
              @change="onFileChange"
            />
          </div>
        </li>

        <li class="flex flex-col">
          <label class="lbl-control">SQL mẫu</label>
          <textarea
            type="text"
            class="ipt-control"
            placeholder="Nhập tên hệ thống"
            v-model="strSqlXXXX"
            v-validate="'required'"
            name="Tên hệ thống"
            spellcheck="false"
            style="height:77px"
          />
          <span
            v-show="errors.has('Tên hệ thống')"
            class="text-danger"
          >
            {{ errors.first("Tên hệ thống") }}
          </span>
        </li>

        <li class="flex flex-col">
          <label class="lbl-control">strSqlMauInsertBrandSerial SQL format để replace(sửa ở đây rồi bấm chọn file
            Excel)</label>
          <textarea
            type="text"
            class="ipt-control"
            placeholder="Nhập tên hệ thống"
            v-model="strSqlMauInsertBrandSerial"
            v-validate="'required'"
            name="Tên hệ thống"
            spellcheck="false"
            style="height:100px"
          />
          <span
            v-show="errors.has('Tên hệ thống')"
            class="text-danger"
          >
            {{ errors.first("Tên hệ thống") }}
          </span>
        </li>

        <li class="flex flex-col">
          <label class="lbl-control">Script output insert bảng BrandSerial strSqlInsertAllBrandSerial</label>
          <textarea
            type="text"
            class="ipt-control"
            placeholder=""
            v-model="strSqlInsertAllBrandSerial"
            v-validate="'required'"
            name="Tên hệ thống"
            spellcheck="false"
            style="height:700px"
          />
          <span
            v-show="errors.has('Tên hệ thống')"
            class="text-danger"
          >
            {{ errors.first("Tên hệ thống") }}
          </span>
        </li>

        <li class="flex flex-col">
          <label class="lbl-control">strSqlMauInsertBrandEquipmentCategory SQL format để replace(sửa ở đây rồi bấm chọn
            file Excel)</label>
          <textarea
            type="text"
            class="ipt-control"
            placeholder="Nhập tên hệ thống"
            v-model="strSqlMauInsertBrandEquipmentCategory"
            v-validate="'required'"
            name="Tên hệ thống"
            spellcheck="false"
            style="height:100px"
          />
          <span
            v-show="errors.has('Tên hệ thống')"
            class="text-danger"
          >
            {{ errors.first("Tên hệ thống") }}
          </span>
        </li>

        <li class="flex flex-col">
          <label class="lbl-control">Script output insert bảng BrandEquipmentCategory strBrandEquipmentCategory</label>
          <textarea
            type="text"
            class="ipt-control"
            placeholder=""
            v-model="strBrandEquipmentCategory"
            v-validate="'required'"
            name="Tên hệ thống"
            spellcheck="false"
            style="height:700px"
          />
          <span
            v-show="errors.has('Tên hệ thống')"
            class="text-danger"
          >
            {{ errors.first("Tên hệ thống") }}
          </span>
        </li>

        <li class="flex flex-col">
          <label class="lbl-control">listBoNganh</label>
          <textarea
            type="text"
            class="ipt-control"
            placeholder="Nhập tên hệ thống"
            v-model="strlistBoNganh"
            v-validate="'required'"
            name="Tên hệ thống"
            spellcheck="false"
            style="height:200px"
          />
          <span
            v-show="errors.has('Tên hệ thống')"
            class="text-danger"
          >
            {{ errors.first("Tên hệ thống") }}
          </span>
        </li>

        <li class="flex flex-col">
          <label class="lbl-control">ListDonViCon</label>
          <textarea
            type="text"
            class="ipt-control"
            placeholder="Nhập tên hệ thống"
            v-model="strListDonViCon"
            v-validate="'required'"
            name="Tên hệ thống"
            spellcheck="false"
            style="height:400px"
          />
          <span
            v-show="errors.has('Tên hệ thống')"
            class="text-danger"
          >
            {{ errors.first("Tên hệ thống") }}
          </span>
        </li>

      </ul>
    </div>


    <div class="container">
      <div class="row justify-content-center">
        <div class="col-lg-12">
          <div class="card shadow-lg border-0 rounded-lg mt-5">

            <div class="card-header">
              <h3 class="text-center font-weight-light my-4">
                <a
                  href="#"
                  class="link-dark text-decoration-none"
                  style='cursor: default;'
                >pages\importexceltinhlocality\index.vue</a>
              </h3>
            </div>

            <div class="card-body">

              <form method="post">

                <div class="d-flex align-items-center justify-content-center mt-4 mb-0">
                  <button
                    class="btn btn-primary"
                    type="submit"
                    v-on:click.prevent="onCopy"
                  >Copy output</button>
                </div>

              </form>
            </div>
            <div class="card-footer text-center py-3">
              <div class="small">...</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<!-- <h4>pages/query/page-list-equipment.vue</h4> -->

<script>
import readXlsxFile from "read-excel-file";
export default {
  name: 'page-list-equipment',
  layout: 'level',
  props: {

  },
  data() {
    return {
      strlistBoNganh: "",
      strListDonViCon: "",
      strSqlInsertAllBrandSerial: "",
      strBrandEquipmentCategory: "",
      strSqlXXXX:
        "INSERT INTO [dbo].[BrandSerial]"
        + "([EquipmentId],[BrandId],[SerialName],[Description],[Type])"
        + " VALUES ({EquipmentId},{BrandId},N'{SerialName}',N'{Description}',{Type}) \nGO",
      strSqlMauInsertBrandSerial:
        "INSERT INTO [dbo].[BrandSerial]"
        + "([EquipmentId],[BrandId],[SerialName],[Description],[Type])"
        + " VALUES ({EquipmentId},{BrandId},N'{SerialName}',N'{Description}',{Type}) \nGO",
      strSqlMauInsertBrandEquipmentCategory:
        "INSERT INTO [dbo].[BrandEquipmentCategory]"
        + "([BrandId],[EquipmentCategoryId])"
        + " VALUES ({BrandId},{EquipmentCategoryId}) \nGO",

      strMessage: "",
      isLogin: true,
      strJsonGetUpdates: "",
      strLoiLogin: "",
      strFilter: "/",
      strTextAfterFilter: "",
      strLastText: "",
    };
  },
  methods: {

    onFileChange(event) {
      let xlsxfile = event.target.files ? event.target.files[0] : null;

      let strOutput = "";
      let strBangMoiOutput = "";
      let intIndexRow = -1;
      console.log("rows:");
      const arrDevice = [
        "Network"
        , "Security"
        , "Server"
      ];
      const arrBrandHangThietBi = [
        "Cisco"
        , "Juniper Networks"
        , "Aruba Networks (HPE)"
        , "Ubiquiti Networks"
        , "HPE"
        , "Dell EMC"
        , "Extreme Networks"
        , "Netgear"
        , "TP-Link"
        , "Symantec (Broadcom)"
        , "Fortinet"
        , "Check Point"
        , "Palo Alto Networks"
        , "McAfee"
        , "Trend Micro"
        , "Sophos"
        , "Barracuda Networks"
        , "IBM"
        , "Lenovo"
        , "Supermicro"
        , "Fujitsu"
        , "Inspur"
        , "Oracle"
      ];
      const arrEquipmentCategoryChungLoai = [
        "Router"
        , "Switch"
        , "Wireless Access Point"
        , "Firewalls"
        , "Security Appliances"
        , "Cybersecurity Solutions"
        , "Security and Data Protection"
        , "Server"
      ];

      strOutput += "\nBEGIN TRANSACTION; \nGO\n";
      strBangMoiOutput += "\nBEGIN TRANSACTION; \nGO\n";

      arrBrandHangThietBi.forEach((itemHang, intIndexHang) => {
        arrEquipmentCategoryChungLoai.forEach((itemChungLoai, intIndexChungLoai) => {

          let strTemp = "" + this.strSqlMauInsertBrandEquipmentCategory.replaceAll("{BrandId}", "" + (intIndexHang + 1));
          strTemp = strTemp.replaceAll("{EquipmentCategoryId}", "" + (intIndexChungLoai + 1));
          strBangMoiOutput += "\n" + strTemp;
        });

      });
      readXlsxFile(xlsxfile).then((rows) => {
        rows.forEach((element) => {
          //   console.log("rows:");
          intIndexRow += 1;
          if (intIndexRow == 0) {
            return;
          }

          console.log(element);
          let intIndexColumn = 0;

          intIndexColumn += 1;
          let strType = element[intIndexColumn];
          strType = this.getIdFromIndexArray(arrDevice, strType);

          intIndexColumn += 1;
          let strBrandId = element[intIndexColumn];
          strBrandId = this.getIdFromIndexArray(arrBrandHangThietBi, strBrandId);

          intIndexColumn += 1;
          let strEquipmentId = element[intIndexColumn];
          strEquipmentId = this.getIdFromIndexArray(arrEquipmentCategoryChungLoai, strEquipmentId);

          intIndexColumn += 1;
          let strSerialName = element[intIndexColumn];

          let strDescription = "";

          let strTemp = "" + this.strSqlMauInsertBrandSerial.replaceAll("{EquipmentId}", strEquipmentId);
          strTemp = strTemp.replaceAll("{BrandId}", strBrandId);
          strTemp = strTemp.replaceAll("{SerialName}", strSerialName);
          strTemp = strTemp.replaceAll("{Description}", strDescription);
          strTemp = strTemp.replaceAll("{Type}", strType);
          strOutput += "\n" + strTemp;

        });
        strOutput += "\nCOMMIT TRANSACTION; \nGO\n";
        strBangMoiOutput += "\nCOMMIT TRANSACTION; \nGO\n";

        this.strSqlInsertAllBrandSerial = strOutput.trim();
        this.strBrandEquipmentCategory = strBangMoiOutput.trim();
      });
    },

    getIdFromIndexArray(arrTemp, strType) {
      let strTempLower = strType.trim().toLowerCase();
      arrTemp.forEach((item, intIndex) => {
        let strTempLowerTwo = item.trim().toLowerCase();
        if (strTempLowerTwo == strTempLower) {
          strType = "" + (intIndex + 1);
          return;
        }
      });
      return strType;
    },

  },
}
</script>

<style></style>