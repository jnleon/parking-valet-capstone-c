<template>
  <div id="dodge">
    <b-container fluid>
      <!-- User Interface controls -->
      <b-row>
        <b-col lg="6" class="my-1"> </b-col>

        <b-col lg="6" class="my-1">
          <b-form-group
            label="Filter"
            label-cols-sm="3"
            label-align-sm="right"
            label-size="sm"
            label-for="filterInput"
            class="mb-0"
            id="filterCarDeets"
          >
            <b-input-group size="sm">
              <b-form-input
                v-model="filter"
                type="search"
                id="filterInput"
                placeholder="Type to Search"
              ></b-form-input>
              <b-input-group-append>
                <b-button :disabled="!filter" @click="filter = ''"
                  >Clear</b-button
                >
              </b-input-group-append>
            </b-input-group>
          </b-form-group>
        </b-col>
      </b-row>

      <b-table
        show-empty
        small
        stacked="md"
        :items="this.$store.state.checkedInCars"
        :fields="fields"
        :current-page="currentPage"
        :per-page="perPage"
        :filter="filter"
        :filter-included-fields="filterOn"
        :sort-by.sync="sortBy"
        :sort-desc.sync="sortDesc"
        :sort-direction="sortDirection"
        @filtered="onFiltered"
      >
        <template #cell(name)="row">
          {{ row.value.first }} {{ row.value.last }}
        </template>

        <template #cell(actions)="row">
          <b-button size="sm" @click="row.toggleDetails">
            {{ row.detailsShowing ? "Hide" : "Show" }} Details
          </b-button>
        </template>

        <template #row-details="row">
          <b-card>
            <div id="listStuffModal">
              <!-- <li v-for="(value, key) in row.item" :key="key">
                {{ key }}: {{ value }}
              </li>-->
              <h5>
                LICENSE PLATE :
                <p style="display: inline" contenteditable="true"></p>
             {{row.item.licensePlate}}
              </h5>

              <h5>
                PATRON ID :
                <p style="display: inline"></p>
              {{row.item.patronId}}
              </h5>

              <h5>
                VEHICLE MAKE :
                <p style="display: inline"></p>
                 {{row.item.vehicleMake}}
              </h5>

              <h5>
                VEHICLE MODEL :
                <p style="display: inline"></p>
               {{row.item.vehicleModel}}
              </h5>

              <h5>
                VEHICLE COLOR :
                <p style="display: inline"></p>
                 {{row.item.vehicleColor}}
              </h5>

            </div>
          </b-card>
        </template>
      </b-table>
    </b-container>
  </div>
</template>

<script>
import ParkingLotService from "@/services/ParkingLotService.js";

export default {
  name: "list-of-cars",

  created() {
    ParkingLotService.getCheckedInCars().then((response) => {
      this.$store.commit("LOAD_CAR_LIST", response.data);
    });
  },
  data() {
    return {
      row: {
        item: {
          vehicleModel: "",
          vehicleColor: "",
        },
        changePatronId: "",
      },
      fields: [
        { key: "vehicleMake", sortable: true, sortDirection: "desc" },
        { key: "vehicleModel", sortable: true, class: "text-center" },
        { key: "vehicleColor", sortable: true, class: "text-center" },
        { key: "licensePlate", sortable: true, class: "text-center" },

        {
          sortable: true,
          sortByFormatted: true,
          filterByFormatted: true,
        },
        { key: "actions", label: "Actions" },
      ],
      /* names:{
          1:"License Plate",
            2:LicensePlate,
              3:LicensePlate,
                4:LicensePlate,
        },*/
      totalRows: 1,
      currentPage: 1,
      perPage: 5,
      pageOptions: [5, 10, 15, { value: 100, text: "Show a lot" }],
      sortBy: "",
      sortDesc: false,
      sortDirection: "asc",
      filter: null,
      filterOn: [],
      infoModal: {
        id: "info-modal",
        title: "",
        content: "",
      },
    };
  },
  computed: {
    sortOptions() {
      // Create an options list from our fields
      return this.fields
        .filter((f) => f.sortable)
        .map((f) => {
          return { text: f.label, value: f.key };
        });
    },
  },
  mounted() {
    // Set the initial number of items
    this.totalRows = this.items.length;
  },
  methods: {
    info(item, index, button) {
      this.infoModal.title = `Row index: ${index}`;
      this.infoModal.content = JSON.stringify(item, null, 2);
      this.$root.$emit("bv::show::modal", this.infoModal.id, button);
    },

    onFiltered(filteredItems) {
      // Trigger pagination to update the number of buttons/pages due to filtering
      this.totalRows = filteredItems.length;
      this.currentPage = 1;
    },
  },
};
</script>

<style>
#listStuffModal {
  list-style: none;
}

#filterCarDeets {
  font-size: 4vh !important;
}

#dodge {
  font-family: "Jua", "Times New Roman", Times, serif !important;
  font-size: 2.5vh;
}

tr:only-child {
  text-transform: uppercase;
}
</style>