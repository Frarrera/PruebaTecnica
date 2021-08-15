<template>
    <div class="panel">
        <ValidationObserver ref="observer" v-slot="{ valid }">
            <div class="panel-body">
                <div class="form-horizontal col-md-6">
                    <ValidationProvider id="Name" :rules="'required|max:50'" v-slot="{ errors }">
                        <field label="Name" :error-message="errors[0]">
                            <input name="Name" v-model="form.Name" class="form-control" />
                        </field>
                    </ValidationProvider>
                    <ValidationProvider id="Price" :rules="'required|between:0,1000'" v-slot="{ errors }">
                        <field label="Price" :error-message="errors[0]">
                            <input type="number" name="Price" v-model="form.Price" class="form-control" />
                        </field>
                    </ValidationProvider>
                    <ValidationProvider id="Company" :rules="'required|max:50'" v-slot="{ errors }">
                        <field label="Company" :error-message="errors[0]">
                            <input name="Company" v-model="form.Company" class="form-control" />
                        </field>
                    </ValidationProvider>
                    <ValidationProvider id="AgeConstraing" :rules="'between:0,100'" v-slot="{ errors }">
                        <field label="Maximun Age" :error-message="errors[0]">
                            <input type="number" name="AgeConstraing" v-model="form.AgeConstraing" class="form-control" />
                        </field>
                    </ValidationProvider>
                    <ValidationProvider id="Description" :rules="'max:100'" v-slot="{ errors }">
                        <field label="Description" :error-message="errors[0]">
                            <textarea class="form-control" name="Description" v-model="form.Description" />
                        </field>
                    </ValidationProvider>
                </div>
            </div>
            <div class="panel-footer">
                <div class="pull-right">
                    <button @click="save" type="button" :disabled="!valid" class="btn btn-success btn-sm"><i class="glyphicon glyphicon-floppy-disk"></i> Save</button>
                    <!--<button @click="cancel" type="button" class="btn btn-danger btn-sm"><i class="glyphicon glyphicon-remove"></i> Cancel</button>-->
                    <a class="btn btn-danger btn-sm" href="/Products/Index">Cancel</a>
                </div>
                <div class="clearfix"></div>
            </div>
        </ValidationObserver>
        <Dialog v-model="loading" loading></Dialog>
    </div>
</template>
<script>
    import { isNumber } from 'lodash'
    import { ValidationObserver } from 'vee-validate'
    import { ValidationProvider } from 'vee-validate/dist/vee-validate.full'
    import Field from '../../components/comun/Field.vue'
    import Dialog from '../../components/comun/Dialog.vue'
    import ProductService from '../../services/ProductService'
    export default {
        name: 'FormProduct',
        components: { Field, ValidationObserver, ValidationProvider, Dialog },
        props: {
            Id: Number
        },
        computed: {
            hasId() {
                let Id = parseInt(this.Id)
                return isNumber(Id) && !isNaN(Id)
            }
        },
        data() {
            return {
                loading: false,
                form:{
                    Name: '',
                    Description: '',
                    Company: '',
                    AgeConstraing: '',
                    Price: ''
                }
            }
        },
        methods: {
            save() {
                this.loading = true
                return ProductService.save(this.form).then(response => {
                    this.$emit('saved',true)
                }).catch(error => {

                }).finally(() => {
                    this.loading = false
                })
            },
            cancel() {
                this.$emit('cancel')
            }
        },
        watch: {
            Id(newValue) {
                newValue = parseInt(newValue)
                if (!isNaN(newValue)) {
                    ProductService.find(newValue).then(response => {
                        let data = _.get(response, 'data')
                        if (data) {
                            $.extend(this.form, data)
                        }
                    })
                }
            }
        }, mounted() {
            if (!isNaN(this.Id)) {
                ProductService.find(this.Id).then(response => {
                    let data = _.get(response, 'data')
                    if (data) {
                        $.extend(this.form, data)
                    }
                })
            }
        }
    }
</script>