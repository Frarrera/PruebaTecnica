<template>
    <div ref="mdl" class="modal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div v-if="loading" class="progress" style="margin: 0px;">
                    <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" style="width: 100%">
                        <span class="sr-only">45% Complete</span>
                    </div>
                </div>
                <template v-else>
                    <div class="modal-header">
                        <h5 class="modal-title">{{title}}</h5>
                    </div>
                    <div class="modal-body">
                        <p>{{message}}</p>
                    </div>
                    <div class="modal-footer">
                        <template v-if="confirm">
                            <button type="button" class="btn btn-primary" @click="accept">Accept</button>
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        </template>
                        <button v-else type="button" class="btn btn-primary" @click="accept" data-dismiss="modal">Accept</button>
                    </div>
                </template>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'Dialog',
        props: {
            title: String,
            message: String,
            confirm: Boolean,
            loading: Boolean,
            value: {
                type: Boolean,
                default: false
            }
        },
        methods: {
            open() {
                $(this.$refs.mdl).modal()
                $(this.$refs.mdl).on('hidden.bs.modal', () => {
                    this.$emit('input',false)
                })
            },
            close() {
                $(this.$refs.mdl).modal('hide')
            },
            accept() {
                this.$emit('accept', true)
            }
        },
        watch: {
            value(newValue) {
                console.log(newValue)
                if (newValue) {
                    this.open()
                } else {
                    this.close()
                }
            }
        }
    }
</script>