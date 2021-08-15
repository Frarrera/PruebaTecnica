<template>
    <div class="panel">
        <div class="panel-heading">
            <div class="pull-left">
                <h1 class="panel-title h1">Products</h1>
            </div>
            <div class="pull-right">
                <a href="/Products/Create" class="btn btn-primary"><i class="glyphicon glyphicon-plus"></i> Add new</a>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="panel-body">
            <table v-if="status == 'L'" class="table table-condensed">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Age</th>
                        <th>Price</th>
                        <th>Company</th>
                        <th style="width: 20%;">Options</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="product in products">
                        <td>{{product.Id}}</td>
                        <td>{{product.Name}}</td>
                        <td>{{product.AgeConstraing}}</td>
                        <td>{{product.Price}}</td>
                        <td>{{product.Company}}</td>
                        <td class="table-buttons">
                            <a class="btn btn-primary btn-sm" :href="'/Products/Edit/'+product.Id"><i class="glyphicon glyphicon-pencil"></i> Edit</a>
                            <a class="btn btn-danger btn-sm" @click="showConfirm = true; IdSelected = product.Id;"><i class="glyphicon glyphicon-erase"></i> Delete</a>
                        </td>
                    </tr>
                </tbody>
            </table>
            <form-product v-if="status == 'N'" @cancel="status = 'L'"  @saved="refresh" :id="IdSelected"></form-product>
            <Dialog v-model="showConfirm" title="Confirmar" message="¿Eliminar producto?" confirm @accept="remove"></Dialog>
            <Dialog v-model="loading" loading></Dialog>
        </div>
    </div>
</template>
<script type="text/javascript">
    import ProductService from '../services/ProductService'
    import _ from 'lodash'
    import FormProduct from '../components/products/FormProduct.vue'
    import Dialog from '../components/comun/Dialog.vue'
    export default {
        name: 'Products',
        components: {
            FormProduct, Dialog
        },
        data() {
            return {
                status: 'L',
                showConfirm: false,
                loading: false,
                IdSelected: NaN,
                products: []
            }
        },
        methods: {
            fetch() {
                this.loading = true
                return ProductService.fetch().then(response => {
                    this.products = _.get(response, 'data', [])
                }).finally(() => {
                    this.loading = false
                })
            },
            remove() {
                this.showConfirm = false
                this.loading = true
                ProductService.remove(this.IdSelected).then(response => {
                    this.fetch()
                }).finally(() => {
                    this.loading = false
                })
            },
            setEdit(id) {
                this.IdSelected = id
                this.status = 'N'
            },
            refresh() {
                this.status = 'L';
                this.IdSelected = NaN;
                this.fetch()
            }
        },
        mounted() {
            this.fetch()
        }
    }
</script>