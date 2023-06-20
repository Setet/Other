import math
from flask import Flask, render_template, request


def predict(a_h0, alpha_deg, b_m, ho_m, Rb_MPa, mu_perc, E_MPa):
    __statist_max_input = [0 for _ in range(7)]
    __statist_max_input[0] = 3.20000000000000e+000
    __statist_max_input[1] = 9.00000000000000e+001
    __statist_max_input[2] = 1.00000000000000e-001
    __statist_max_input[3] = 8.30000000000000e-001
    __statist_max_input[4] = 3.35000000000000e+001
    __statist_max_input[5] = 3.29000000000000e+000
    __statist_max_input[6] = 2.00000000000000e+002
    __statist_min_input = [0 for _ in range(7)]
    __statist_min_input[0] = 1.60000000000000e+000
    __statist_min_input[1] = 4.50000000000000e+001
    __statist_min_input[2] = 3.00000000000000e-002
    __statist_min_input[3] = 2.60000000000000e-001
    __statist_min_input[4] = 1.42506000000000e+001
    __statist_min_input[5] = 4.00000000000000e-001
    __statist_min_input[6] = 6.53000000000000e+001
    __statist_max_target = [0 for _ in range(1)]
    __statist_max_target[0] = 1.16000000000000e+003
    __statist_min_target = [0 for _ in range(1)]
    __statist_min_target[0] = 4.27000000000000e+001
    __statist_i_h_wts = [[0 for _ in range(7)] for _ in range(4)]
    __statist_i_h_wts[0][0] = 3.40785237158611e-001
    __statist_i_h_wts[0][1] = 4.39700437046962e-001
    __statist_i_h_wts[0][2] = -2.94681587960938e+000
    __statist_i_h_wts[0][3] = -3.23829558799677e+000
    __statist_i_h_wts[0][4] = 1.88692981127111e-001
    __statist_i_h_wts[0][5] = -2.68689575358058e+000
    __statist_i_h_wts[0][6] = -1.66941632090395e+000
    __statist_i_h_wts[1][0] = -6.10571679977662e-001
    __statist_i_h_wts[1][1] = -9.71310320866126e-001
    __statist_i_h_wts[1][2] = 9.91619963817874e-001
    __statist_i_h_wts[1][3] = 1.46321041721861e+000
    __statist_i_h_wts[1][4] = 4.58246937475870e-001
    __statist_i_h_wts[1][5] = -3.88475402811468e-002
    __statist_i_h_wts[1][6] = 6.12183468020795e-001
    __statist_i_h_wts[2][0] = -1.05536734970287e+000
    __statist_i_h_wts[2][1] = 7.23765213057669e-001
    __statist_i_h_wts[2][2] = -1.08124779890015e+000
    __statist_i_h_wts[2][3] = -1.04334014598579e+000
    __statist_i_h_wts[2][4] = 2.69696198468984e-001
    __statist_i_h_wts[2][5] = -3.28916851966340e-001
    __statist_i_h_wts[2][6] = -1.30267936937851e+000
    __statist_i_h_wts[3][0] = 1.76602185913090e-001
    __statist_i_h_wts[3][1] = 1.33126770820399e+000
    __statist_i_h_wts[3][2] = -2.52701365452868e+000
    __statist_i_h_wts[3][3] = -3.24503921723058e+000
    __statist_i_h_wts[3][4] = -2.25961725931964e+000
    __statist_i_h_wts[3][5] = -3.21875803920026e-001
    __statist_i_h_wts[3][6] = -1.67435482537682e+000
    __statist_h_o_wts = [[0 for _ in range(4)] for _ in range(1)]
    __statist_h_o_wts[0][0] = -1.21035686283219e+000
    __statist_h_o_wts[0][1] = 1.03983341372449e+000
    __statist_h_o_wts[0][2] = 9.58565089976754e-001
    __statist_h_o_wts[0][3] = -9.13992503324459e-001
    __statist_hidden_bias = [0 for _ in range(4)]
    __statist_hidden_bias[0] = 9.96320522894159e-001
    __statist_hidden_bias[1] = -1.17248572377737e+000
    __statist_hidden_bias[2] = 4.20059323123875e-002
    __statist_hidden_bias[3] = 2.03363808503203e+000
    __statist_output_bias = [0 for _ in range(1)]
    __statist_output_bias[0] = -2.10710196407522e+000
    __statist_inputs = [0 for _ in range(7)]
    __statist_hidden = [0 for _ in range(4)]
    __statist_outputs = [0 for _ in range(1)]
    __statist_outputs[0] = -1.0e+307
    __statist_inputs[0] = a_h0
    __statist_inputs[1] = alpha_deg
    __statist_inputs[2] = b_m
    __statist_inputs[3] = ho_m
    __statist_inputs[4] = Rb_MPa
    __statist_inputs[5] = mu_perc
    __statist_inputs[6] = E_MPa
    __statist_delta = 0
    __statist_maximum = 1
    __statist_minimum = 0
    __statist_ncont_inputs = 7

    # scale continuous inputs
    __statist_i = 0
    while __statist_i < __statist_ncont_inputs:
        # C# TO PYTHON CONVERTER TASK: C# to Python Converter cannot determine whether both operands of this division are integer types - if they are then you should change 'lhs / rhs' to 'math.trunc(lhs / float(rhs))':
        __statist_delta = (__statist_maximum - __statist_minimum) / (
                __statist_max_input[__statist_i] - __statist_min_input[__statist_i])
        __statist_inputs[__statist_i] = __statist_minimum - __statist_delta * __statist_min_input[
            __statist_i] + __statist_delta * __statist_inputs[__statist_i]
        __statist_i += 1
    __statist_ninputs = 7
    __statist_nhidden = 4
    # Compute feed forward signals from Input layer to hidden layer
    for __statist_row in range(0, __statist_nhidden):
        __statist_hidden[__statist_row] = 0.0
        for __statist_col in range(0, __statist_ninputs):
            __statist_hidden[__statist_row] = __statist_hidden[__statist_row] + (
                    __statist_i_h_wts[__statist_row][__statist_col] * __statist_inputs[__statist_col])
        __statist_hidden[__statist_row] = __statist_hidden[__statist_row] + __statist_hidden_bias[__statist_row]
    for __statist_row in range(0, __statist_nhidden):
        if __statist_hidden[__statist_row] > 100.0:
            __statist_hidden[__statist_row] = 1.0
        else:
            if __statist_hidden[__statist_row] < -100.0:
                __statist_hidden[__statist_row] = -1.0
            else:
                __statist_hidden[__statist_row] = math.tanh(__statist_hidden[__statist_row])
    __statist_noutputs = 1
    # Compute feed forward signals from hidden layer to output layer
    for __statist_row2 in range(0, __statist_noutputs):
        __statist_outputs[__statist_row2] = 0.0
        for __statist_col2 in range(0, __statist_nhidden):
            __statist_outputs[__statist_row2] = __statist_outputs[__statist_row2] + (
                    __statist_h_o_wts[__statist_row2][__statist_col2] * __statist_hidden[__statist_col2])
        __statist_outputs[__statist_row2] = __statist_outputs[__statist_row2] + __statist_output_bias[__statist_row2]
    for __statist_row in range(0, __statist_noutputs):
        if __statist_outputs[__statist_row] > 100.0:
            __statist_outputs[__statist_row] = 1.0
        else:
            __statist_outputs[__statist_row] = math.exp(__statist_outputs[__statist_row])
    # Unscale continuous targets
    __statist_delta = 0
    for __statist_i in range(0, __statist_noutputs):
        # C# TO PYTHON CONVERTER TASK: C# to Python Converter cannot determine whether both operands of this division are integer types - if they are then you should change 'lhs / rhs' to 'math.trunc(lhs / float(rhs))':
        __statist_delta = (__statist_maximum - __statist_minimum) / (
                __statist_max_target[__statist_i] - __statist_min_target[__statist_i])
        # C# TO PYTHON CONVERTER TASK: C# to Python Converter cannot determine whether both operands of this division are integer types - if they are then you should change 'lhs / rhs' to 'math.trunc(lhs / float(rhs))':
        __statist_outputs[__statist_i] = (__statist_outputs[__statist_i] - __statist_minimum + __statist_delta *
                                          __statist_min_target[__statist_i]) / __statist_delta
    for __statist_ii in range(0, __statist_noutputs):
        return __statist_outputs[__statist_ii]


app = Flask(__name__)

# адрес
host = '127.0.0.1'
# порт
port = 2001


@app.route('/test_1', methods=['GET', 'POST'])
def new_post():
    if request.method == 'POST':
        a_h0 = float(request.form['a_h0'])
        alpha_deg = float(request.form['alpha_deg'])
        b_m = float(request.form['b_m'])
        ho_m = float(request.form['ho_m'])
        Rb_MPa = float(request.form['Rb_MPa'])
        mu_perc = float(request.form['mu_perc'])
        E_MPa = float(request.form['E_MPa'])

        Q = predict(a_h0, alpha_deg, b_m, ho_m, Rb_MPa, mu_perc, E_MPa)

        # return redirect(url_for('index'))
        return render_template('index.html', Qresult=Q)

    return render_template('index.html')


if __name__ == '__main__':
    app.run(host=host, port=port, debug=True)
