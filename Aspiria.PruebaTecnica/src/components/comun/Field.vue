<template>
    <div :class="{ 'form-group form-group-sm': true, 'has-error': hasError} ">
        <label class="control-label col-md-2">{{label}}:</label>
        <div class="col-md-10">
            <slot>
                <input class="form-control" />
            </slot>
            <span class="text-danger small">{{ErrorMessage}}</span>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'Field',
        props: {
            label: String,
            ErrorMessage: String
        },
        computed: {
            hasError() {
                return this.ErrorMessage || false
            }
        }
    }
</script>
<style scoped>
    .control-label.col-sm-1 {
        padding: 0px;
        text-align: right;
    }
</style>