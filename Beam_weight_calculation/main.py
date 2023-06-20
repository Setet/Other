import math
from flask import Flask, render_template, request


def predict(a_h0, alpha_deg, b_m, ho_m, Rb_MPa, mu_perc, E_MPa):
    statist_max_input = [3.2, 90, 0.1, 0.83, 33.5, 3.29, 200]
    statist_min_input = [1.6, 45, 0.03, 0.26, 14.2506, 0.4, 65.3]
    statist_max_target = [1.16000000000000e+003]
    statist_min_target = [4.27000000000000e+001]
    statist_i_h_wts = [
        [3.40785237158611e-001, 4.39700437046962e-001, -2.94681587960938e+000, -3.23829558799677e+000,
         1.88692981127111e-001, -2.68689575358058e+000, -1.66941632090395e+000],
        [-6.10571679977662e-001, -9.71310320866126e-001, 9.91619963817874e-001, 1.46321041721861e+000,
         4.58246937475870e-001, -3.88475402811468e-002, 6.12183468020795e-001],
        [-1.05536734970287e+000, 7.23765213057669e-001, -1.08124779890015e+000, -1.04334014598579e+000,
         2.69696198468984e-001, -3.28916851966340e-001, -1.30267936937851e+000],
        [1.76602185913090e-001, 1.33126770820399e+000, -2.52701365452868e+000, -3.24503921723058e+000,
         -2.25961725931964e+000, -3.21875803920026e-001, -1.67435482537682e+000]
    ]
    statist_h_o_wts = [[-1.21035686283219e+000, 1.03983341372449e+000, 9.58565089976754e-001, -9.13992503324459e-001]]
    statist_hidden_bias = [9.96320522894159e-001, -1.17248572377737e+000, 4.20059323123875e-002, 2.03363808503203e+000]
    statist_output_bias = [-2.10710196407522e+000]
    statist_inputs = [a_h0, alpha_deg, b_m, ho_m, Rb_MPa, mu_perc, E_MPa]
    statist_hidden = [0 for _ in range(4)]
    statist_outputs = [-1.0e+307]
    statist_maximum = 1
    statist_minimum = 0
    statist_ncont_inputs = 7
    # scale continuous inputs
    statist_ninputs = 7
    statist_nhidden = 4
    statist_noutputs = 1

    for i in range(statist_ncont_inputs):
        delta = (statist_maximum - statist_minimum) / (statist_max_input[i] - statist_min_input[i])
        statist_inputs[i] = statist_minimum - delta * statist_min_input[i] + delta * statist_inputs[i]

    for row in range(statist_nhidden):
        statist_hidden[row] = 0.0
        for col in range(statist_ninputs):
            statist_hidden[row] += statist_i_h_wts[row][col] * statist_inputs[col]
        statist_hidden[row] += statist_hidden_bias[row]
        if statist_hidden[row] > 100.0:
            statist_hidden[row] = 1.0
        elif statist_hidden[row] < -100.0:
            statist_hidden[row] = -1.0
        else:
            statist_hidden[row] = math.tanh(statist_hidden[row])

    for row2 in range(statist_noutputs):
        statist_outputs[row2] = 0.0
        for col2 in range(statist_nhidden):
            statist_outputs[row2] += statist_h_o_wts[row2][col2] * statist_hidden[col2]
        statist_outputs[row2] += statist_output_bias[row2]
        if statist_outputs[row2] > 100.0:
            statist_outputs[row2] = 1.0
        else:
            statist_outputs[row2] = math.exp(statist_outputs[row2])

    for i in range(statist_noutputs):
        delta = (statist_maximum - statist_minimum) / (statist_max_target[i] - statist_min_target[i])
        statist_outputs[i] = (statist_outputs[i] - statist_minimum + delta * statist_min_target[i]) / delta

    return statist_outputs[0]


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

        result = predict(a_h0, alpha_deg, b_m, ho_m, Rb_MPa, mu_perc, E_MPa)

        # return redirect(url_for('index'))
        return render_template('index.html', Qresult=result)

    return render_template('index.html')


if __name__ == '__main__':
    app.run(host=host, port=port, debug=True)
